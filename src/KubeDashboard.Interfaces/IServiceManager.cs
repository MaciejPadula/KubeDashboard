using KubeDashboard.Model;

namespace KubeDashboard.Interfaces;

public interface IServiceManager
{
    Task AddService(string serviceName, string kNamespace, LoadBalancerConfiguration configuration);
}
