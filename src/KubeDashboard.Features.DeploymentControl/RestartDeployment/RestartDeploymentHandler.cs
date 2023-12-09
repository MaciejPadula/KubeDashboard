using KubeDashboard.Interfaces;
using MediatR;

namespace KubeDashboard.Features.DeploymentControl.RestartDeployment;

internal record class RestartDeploymentRequest(string Namespace, string DeploymentName) : IRequest;

internal class RestartDeploymentHandler : IRequestHandler<RestartDeploymentRequest>
{
    private readonly IDeploymentManager _deploymentManager;

    public RestartDeploymentHandler(IDeploymentManager deploymentManager)
    {
        _deploymentManager = deploymentManager;
    }

    public async Task Handle(RestartDeploymentRequest request, CancellationToken cancellationToken)
    {
        await _deploymentManager.Restart(request.Namespace, request.DeploymentName);
    }
}
