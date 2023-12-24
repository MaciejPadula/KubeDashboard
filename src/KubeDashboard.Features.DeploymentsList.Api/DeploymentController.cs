using KubeDashboard.Api;
using KubeDashboard.Features.DeploymentsList.Api.Response;
using KubeDashboard.Features.DeploymentsList.GetDeploymentPods;
using KubeDashboard.Features.DeploymentsList.GetDeployments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KubeDashboard.Features.DeploymentsList.Api;

public class DeploymentController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public DeploymentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{namespace}")]
    public async Task<GetDeploymentsListResponse> GetDeploymentsList(string @namespace)
    {
        var result = await _mediator.Send(new GetDeploymentsQuery(@namespace));
        return new(result);
    }

    [HttpGet("{namespace}/{deployment}")]
    public async Task<GetDeploymentPodsResponse> GetDeploymentPods(string @namespace, string deployment)
    {
        var result = await _mediator.Send(new GetDeploymentPodsQuery(deployment, @namespace));
        return new(result.AlivePods, result.DeadPods);
    }
}
