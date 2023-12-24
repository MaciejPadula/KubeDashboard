using KubeDashboard.Interfaces;
using MediatR;

namespace KubeDashboard.Features.DeploymentControl.AddEnvironmentVariables;

public record class AddEnvironmentVariablesCommand(
    string Namespace,
    string DeploymentName,
    Dictionary<string, string> EnvironmentVariables) : IRequest;

internal class AddEnvironmentVariablesHandler : IRequestHandler<AddEnvironmentVariablesCommand>
{
    private readonly IDeploymentManager _deploymentManager;

    public AddEnvironmentVariablesHandler(IDeploymentManager deploymentManager)
    {
        _deploymentManager = deploymentManager;
    }

    public async Task Handle(AddEnvironmentVariablesCommand request, CancellationToken cancellationToken)
    {
        await _deploymentManager.AddDeploymentEnvironmentVariables(
            request.DeploymentName,
            request.Namespace,
            request.EnvironmentVariables);
    }
}
