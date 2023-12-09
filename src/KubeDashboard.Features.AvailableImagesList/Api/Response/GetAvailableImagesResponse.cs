using KubeDashboard.Model;

namespace KubeDashboard.Features.AvailableImagesList.Api.Response;

public record class GetAvailableImagesResponse(List<Image> Images);
