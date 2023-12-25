using k8s;
using k8s.Models;
using KubeDashboard.Interfaces;
using KubeDashboard.Model;

namespace KubeDashboard.Infrastructure;

internal class KubernetesServiceManager : IServiceManager
{
    private readonly IKubernetes _kubernetes;

    public KubernetesServiceManager(IKubernetes kubernetes)
    {
        _kubernetes = kubernetes;
    }

    public Task AddCronJob(string serviceName, string deploymentName, string kNamespace)
    {
        throw new NotImplementedException();
    }

    public async Task AddLoadBalancer(string serviceName, string deploymentName, string kNamespace, LoadBalancerConfiguration configuration)
    {
        var service = new V1Service
        {
            ApiVersion = "v1",
            Kind = "Service",
            Metadata = new V1ObjectMeta
            {
                Name = serviceName,
                NamespaceProperty = kNamespace
            },
            Spec = new V1ServiceSpec
            {
                Type = "LoadBalancer",
                Ports = configuration.Ports
                    .Select(p => new V1ServicePort()
                    {
                        Protocol = p.Protocol,
                        Port = p.Port,
                        TargetPort = p.TargetPort
                    })
                    .ToList(),
                ExternalIPs = configuration.ExternalIPs,
                Selector = new Dictionary<string, string>
                {
                    { "app", deploymentName }
                }
            }
        };

        await _kubernetes.CoreV1.ReplaceNamespacedServiceAsync(service, serviceName, kNamespace);
    }
}
