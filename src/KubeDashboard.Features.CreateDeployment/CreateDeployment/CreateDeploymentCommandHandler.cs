using KubeDashboard.Interfaces;
using KubeDashboard.Model;
using MediatR;

namespace KubeDashboard.Features.CreateDeployment.CreateDeployment;

public record class CreateDeploymentCommand(string Name, int Replicas, IEnumerable<Container> Containers, string Namespace) : IRequest;

internal class CreateDeploymentCommandHandler : IRequestHandler<CreateDeploymentCommand>
{
    private readonly IDeploymentManager _deploymentManager;

    public CreateDeploymentCommandHandler(IDeploymentManager deploymentManager)
    {
        _deploymentManager = deploymentManager;
    }

    public async Task Handle(CreateDeploymentCommand request, CancellationToken cancellationToken)
    {
        await _deploymentManager.AddDeployment(new Deployment
        {
            Name = request.Name,
            Replicas = request.Replicas,
            Containers = request.Containers,
            Namespace = request.Namespace
        });
    }
}
