using KubeDashboard.Api;
using KubeDashboard.Features.CreateDeployment.Api.Request;
using KubeDashboard.Features.CreateDeployment.CreateDeployment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KubeDashboard.Features.CreateDeployment.Api;

public class DeploymentController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public DeploymentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task Create([FromBody] CreateRequest request)
    {
        await _mediator.Send(new CreateDeploymentCommand(
            request.Name, request.Type, request.Replicas, request.Images, request.Namespace));
    }
}
