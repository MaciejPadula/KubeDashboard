using KubeDashboard.Model;

namespace KubeDashboard.Interfaces;

public interface IDeploymentManager
{
    Task AddDeployment(Deployment deployment);
    Task UpdateDeployment(Deployment deployment);
    Task<IEnumerable<Deployment>> GetDeploys(string kNamespace);
    Task<IEnumerable<Pod>> GetPods(string deploymentName, string kNamespace);
    Task<Dictionary<string, string>> GetDeploymentEnvironmentVariables(string deploymentName, string kNamespace);
    Task AddOrUpdateEnvironmentVariables(string deploymentName, string kNamespace, Dictionary<string, string> variables);
    Task Restart(string kNamespace, string name);
}
