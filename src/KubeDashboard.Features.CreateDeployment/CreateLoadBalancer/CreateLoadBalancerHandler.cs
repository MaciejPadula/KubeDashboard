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
    private readonly IDeploymentManager _deploymentManager;

    public CreateLoadBalancerHandler(IServiceManager serviceManager, IDeploymentManager deploymentManager)
    {
        _serviceManager = serviceManager;
        _deploymentManager = deploymentManager;
    }

    public async Task Handle(CreateLoadBalancerCommand request, CancellationToken cancellationToken)
    {
        await _serviceManager.AddService(request.ServiceName, request.Namespace, request.Configuration);
        await _deploymentManager.AddServiceForDeployment(request.DeploymentName, request.ServiceName, request.Namespace);
    }
}
