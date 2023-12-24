using KubeDashboard.Model;

namespace KubeDashboard.Interfaces;

public interface IDeploymentManager
{
    Task CreateDeployment(Deployment deployment);
    Task<IEnumerable<Deployment>> GetDeploys(string kNamespace);
    Task<IEnumerable<Pod>> GetPods(string deploymentName, string kNamespace);
    Task<Dictionary<string, string>> GetDeploymentEnvironmentVariables(string deploymentName, string kNamespace);
    Task AddDeploymentEnvironmentVariables(string deploymentName, string kNamespace, Dictionary<string, string> variables);
    Task AddServiceForDeployment(string deploymentName, string serviceName, string kNamespace);
    Task Restart(string kNamespace, string name);
}
