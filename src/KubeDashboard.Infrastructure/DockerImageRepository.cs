using DockerApi;
using KubeDashboard.Infrastructure.Mappers;
using KubeDashboard.Interfaces;
using KubeDashboard.Model;

namespace KubeDashboard.Infrastructure;

internal class DockerImageRepository : IImageRepository
{
    private readonly IDockerClient _dockerClient;

    public DockerImageRepository(IDockerClient dockerClient)
    {
        _dockerClient = dockerClient;
    }

    public async Task<IEnumerable<Image>> GetAvailableImages(string registryBaseUrl)
    {
        var response = await _dockerClient.GetDockerImages(registryBaseUrl);
        return response.Select(i => i.ToDto());
    }
}
