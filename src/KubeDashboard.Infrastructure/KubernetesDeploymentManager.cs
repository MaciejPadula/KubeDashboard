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

    public async Task CreateDeployment(Deployment deployment)
    {
        await _kubernetes.AppsV1.CreateNamespacedDeploymentAsync(
            deployment.ToIto(), deployment.Namespace);
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
