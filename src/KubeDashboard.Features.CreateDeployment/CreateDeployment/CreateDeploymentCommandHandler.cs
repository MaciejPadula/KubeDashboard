using KubeDashboard.Interfaces;
using KubeDashboard.Model;
using MediatR;

namespace KubeDashboard.Features.CreateDeployment.CreateDeployment;

internal record class CreateDeploymentCommand(string Name, DeploymentType Type, int Replicas, IEnumerable<TaggedImage> Images, string Namespace) : IRequest;

internal class CreateDeploymentCommandHandler : IRequestHandler<CreateDeploymentCommand>
{
    private readonly IDeploymentManager _deploymentManager;

    public CreateDeploymentCommandHandler(IDeploymentManager deploymentManager)
    {
        _deploymentManager = deploymentManager;
    }

    public async Task Handle(CreateDeploymentCommand request, CancellationToken cancellationToken)
    {
        await _deploymentManager.CreateDeployment(new Deployment
        {
            Name = request.Name,
            Type = request.Type,
            Replicas = request.Replicas,
            Images = request.Images,
            Namespace = request.Namespace
        });
    }
}
