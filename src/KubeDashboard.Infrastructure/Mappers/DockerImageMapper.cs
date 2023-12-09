using DockerApi.Model;
using KubeDashboard.Model;

namespace KubeDashboard.Infrastructure.Mappers;

internal static class DockerImageMapper
{
    internal static Image ToDto(this DockerImage image) =>
        new(image.Name, image.Tags);
}
