using KubeDashboard.Interfaces;
using KubeDashboard.Model;
using MediatR;

namespace KubeDashboard.Features.AvailableImagesList.GetAvailableImages;

public record class GetAvailableItemsQuery(string RegistryBaseUrl) : IRequest<List<Image>>;

internal class GetAvailableImagesHandler : IRequestHandler<GetAvailableItemsQuery, List<Image>>
{
    private readonly IImageRepository _imageRepository;

    public GetAvailableImagesHandler(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    public async Task<List<Image>> Handle(GetAvailableItemsQuery request, CancellationToken cancellationToken)
    {
        var images = await _imageRepository.GetAvailableImages(request.RegistryBaseUrl);

        return images
            .OrderBy(i => i.Name)
            .ToList();
    }
}
