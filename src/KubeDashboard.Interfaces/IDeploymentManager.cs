using KubeDashboard.Model;

namespace KubeDashboard.Interfaces;

public interface IDeploymentManager
{
    Task CreateDeployment(Deployment deployment);
    Task<IEnumerable<Deployment>> GetDeploys(string kNamespace);
    Task Restart(string kNamespace, string name);
}
