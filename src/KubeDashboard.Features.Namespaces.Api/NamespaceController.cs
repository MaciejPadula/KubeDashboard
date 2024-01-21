using KubeDashboard.Api;
using KubeDashboard.Features.Namespaces.Api.Response;
using KubeDashboard.Features.Namespaces.GetNamespaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KubeDashboard.Features.Namespaces.Api;

public class NamespaceController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public NamespaceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<GetNamespacesResponse> GetNamespaces()
    {
        var result = await _mediator.Send(new GetNamespacesQuery());
        return new GetNamespacesResponse(result);
    }
}
