using KubeDashboard.Interfaces;
using KubeDashboard.Model;
using MediatR;

namespace KubeDashboard.Features.CreateDeployment.CreateLoadBalancer;

public record class CreateLoadBalancerCommand(
    string DeploymentName,
    string ServiceName,
    string Namespace,
    LoadBalancerConfiguration Configuration) : IRequest;

internal class CreateLoadBalancerHandler : IRequestHandler<CreateLoadBalancerCommand>
{
    private readonly IServiceManager _serviceManager;

    public CreateLoadBalancerHandler(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public async Task Handle(CreateLoadBalancerCommand request, CancellationToken cancellationToken)
    {
        await _serviceManager.AddLoadBalancer(
            request.ServiceName,
            request.DeploymentName,
            request.Namespace,
            request.Configuration);
    }
}
