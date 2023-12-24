using KubeDashboard.Interfaces;
using MediatR;

namespace KubeDashboard.Features.DeploymentControl.RestartDeployment;

public record class RestartDeploymentCommand(string Namespace, string DeploymentName) : IRequest;

internal class RestartDeploymentHandler : IRequestHandler<RestartDeploymentCommand>
{
    private readonly IDeploymentManager _deploymentManager;

    public RestartDeploymentHandler(IDeploymentManager deploymentManager)
    {
        _deploymentManager = deploymentManager;
    }

    public async Task Handle(RestartDeploymentCommand request, CancellationToken cancellationToken)
    {
        await _deploymentManager.Restart(request.Namespace, request.DeploymentName);
    }
}
