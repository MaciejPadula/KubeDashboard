using Json.Patch;
using k8s;
using k8s.Models;
using KubeDashboard.Infrastructure.Mappers;
using KubeDashboard.Interfaces;
using KubeDashboard.Model;
using System.Text.Json;

namespace KubeDashboard.Infrastructure;

internal class KubernetesDeploymentManager : IDeploymentManager
{
    private readonly IKubernetes _kubernetes;

    public KubernetesDeploymentManager(IKubernetes kubernetes)
    {
        _kubernetes = kubernetes;
    }

    public async Task AddDeploymentEnvironmentVariables(string deploymentName, string kNamespace, Dictionary<string, string> variables)
    {
        var deploys = await _kubernetes.AppsV1.ListNamespacedDeploymentAsync(kNamespace);
        var deploy = deploys.Items.FirstOrDefault(d => d.Name() == deploymentName);

        var containers = deploy?.Spec?.Template?.Spec?.Containers;

        if (containers is null)
        {
            return;
        }

        foreach (var variable in variables.Select(v => new V1EnvVar(v.Key, v.Value)))
        {
            foreach (var container in containers)
            {
                if (container.Env is null)
                {
                    container.Env = new List<V1EnvVar>();
                }

                var existingVariable = container.Env.FirstOrDefault(e => e.Name == variable.Name);
                if (existingVariable is null)
                {
                    container.Env.Add(variable);
                }
                else
                {
                    existingVariable.Value = variable.Value;
                }
            }
        }

        await _kubernetes.AppsV1.ReplaceNamespacedDeploymentAsync(deploy, deploymentName, kNamespace);
    }

    public async Task CreateDeployment(Deployment deployment)
    {
        await _kubernetes.AppsV1.CreateNamespacedDeploymentAsync(
            deployment.ToIto(), deployment.Namespace);
    }

    public async Task<Dictionary<string, string>> GetDeploymentEnvironmentVariables(string deploymentName, string kNamespace)
    {
        var deploys = await _kubernetes.AppsV1.ListNamespacedDeploymentAsync(kNamespace);
        var deploy = deploys.Items.FirstOrDefault(d => d.Name() == deploymentName);

        return deploy?.Spec?.Template?.Spec?.Containers?
            .SelectMany(c => c.Env)?
            .ToDictionary(e => e.Name, e => e.Value) ?? [];
    }

    public async Task<IEnumerable<Deployment>> GetDeploys(string kNamespace)
    {
        var deploy = await _kubernetes.AppsV1.ListNamespacedDeploymentAsync(kNamespace);
        return deploy.Items.Select(d => d.ToDto());
    }

    public async Task<IEnumerable<Pod>> GetPods(string deploymentName, string kNamespace)
    {
        var pods = await _kubernetes.CoreV1.ListNamespacedPodAsync(kNamespace);

        return pods.Items
            .Where(p => p.Name().StartsWith(deploymentName))
            .Select(p => new Pod(p.Name(), p.Status.Phase, !p.Status.ContainerStatuses.Any(c => !c.Ready)))
            .ToList();
    }

    public async Task Restart(string kNamespace, string name)
    {
        var deploy = await _kubernetes.AppsV1.ReadNamespacedDeploymentAsync(name, kNamespace);
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        var old = JsonSerializer.SerializeToDocument(deploy, options);
        var now = DateTimeOffset.Now.ToUnixTimeSeconds();

        var restart = new Dictionary<string, string>
        {
            { "date", now.ToString() }
        };

        deploy.Spec.Template.Metadata.Annotations = restart;

        var expected = JsonSerializer.SerializeToDocument(deploy);
        var patch = old.CreatePatch(expected);

        await _kubernetes.AppsV1.PatchNamespacedDeploymentAsync(new V1Patch(
            patch, V1Patch.PatchType.JsonPatch), name, kNamespace);
    }
}
