using KubeDashboard.Api;
using KubeDashboard.Features.AvailableImagesList.Api.Request;
using KubeDashboard.Features.AvailableImagesList.Api.Response;
using KubeDashboard.Features.AvailableImagesList.GetAvailableImages;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KubeDashboard.Features.AvailableImagesList.Api;

public class AvailableImagesController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public AvailableImagesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<GetAvailableImagesResponse> GetAvailableImages([FromBody] GetAvailableImagesRequest request)
    {
        var result = await _mediator.Send(new GetAvailableItemsQuery(
            request.RegistryBaseUrl));

        return new GetAvailableImagesResponse(result);
    }
}
