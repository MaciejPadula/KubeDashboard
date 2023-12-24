using KubeDashboard.Interfaces;
using KubeDashboard.Model;
using MediatR;

namespace KubeDashboard.Features.DeploymentsList.GetDeploymentPods;

public record GetDeploymentPodsQuery(string DeployName, string Namespace) : IRequest<PodsResult>;
public record class PodsResult(List<Pod> AlivePods, List<Pod> DeadPods);

internal class GetDeploymentPodsHandler : IRequestHandler<GetDeploymentPodsQuery, PodsResult>
{
    private readonly IDeploymentManager _deploymentManager;

    public GetDeploymentPodsHandler(IDeploymentManager deploymentManager)
    {
        _deploymentManager = deploymentManager;
    }

    public async Task<PodsResult> Handle(GetDeploymentPodsQuery request, CancellationToken cancellationToken)
    {
        var pods = await _deploymentManager.GetPods(request.DeployName, request.Namespace);
        var result = new PodsResult([], []);

        foreach(var pod in pods)
        {
            var selectedPodsList = pod.IsAlive ? result.AlivePods : result.DeadPods;
            selectedPodsList.Add(pod);
        }

        return result;
    }
}
