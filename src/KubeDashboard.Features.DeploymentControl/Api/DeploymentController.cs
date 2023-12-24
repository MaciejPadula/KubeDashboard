using KubeDashboard.Api;
using KubeDashboard.Features.DeploymentControl.AddEnvironmentVariables;
using KubeDashboard.Features.DeploymentControl.Api.Request;
using KubeDashboard.Features.DeploymentControl.RestartDeployment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KubeDashboard.Features.DeploymentControl.Api;

public class DeploymentController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public DeploymentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task AddEnvironmentVariables([FromBody] AddEnvironmentVariablesCommand request)
    {
        await _mediator.Send(new AddEnvironmentVariablesCommand(
            request.Namespace, request.DeploymentName, request.EnvironmentVariables));
    }

    [HttpPost]
    public async Task Restart([FromBody] RestartRequest request)
    {
        await _mediator.Send(new RestartDeploymentCommand(
            request.Namespace, request.DeploymentName));
    }
}
