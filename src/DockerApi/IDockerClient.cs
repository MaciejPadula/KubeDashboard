using DockerApi.Model;

namespace DockerApi;

public interface IDockerClient
{
    Task<IEnumerable<DockerImage>> GetDockerImages(string registryBaseUrl);
    Task<DockerImage?> GetImageByName(string registryBaseUrl, string imageName);
}
