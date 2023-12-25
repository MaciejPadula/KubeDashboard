using KubeDashboard.Model;

namespace KubeDashboard.Interfaces;

public interface IServiceManager
{
    Task AddLoadBalancer(string serviceName, string deploymentName, string kNamespace, LoadBalancerConfiguration configuration);
    Task AddCronJob(string serviceName, string deploymentName, string kNamespace);
}
