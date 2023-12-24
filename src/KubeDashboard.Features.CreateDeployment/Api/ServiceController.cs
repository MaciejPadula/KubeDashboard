using KubeDashboard.Api;
using KubeDashboard.Features.CreateDeployment.Api.Request;
using KubeDashboard.Features.CreateDeployment.CreateLoadBalancer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KubeDashboard.Features.CreateDeployment.Api;

public class ServiceController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public ServiceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task Create([FromBody] CreateServiceRequest request)
    {
        await _mediator.Send(new CreateLoadBalancerCommand(
            request.DeploymentName,
            request.ServiceName,
            request.Namespace,
            request.Configuration));
    }
}
