using DockerApi.Model;

namespace DockerApi;

internal class DockerHttpClient : IDockerClient
{
    private readonly IEnumerable<IDockerClient> _dockerClients;

    public DockerHttpClient(IEnumerable<IDockerClient> dockerClients)
    {
        _dockerClients = dockerClients;
    }

    public async Task<IEnumerable<DockerImage>> GetDockerImages(string registryBaseUrl)
    {
        var exceptions = new List<Exception>();
        foreach (var dockerClient in _dockerClients)
        {
            try
            {
                return await dockerClient.GetDockerImages(registryBaseUrl);
            }
            catch (Exception e)
            {
                exceptions.Add(e);
            }
        }
        throw exceptions.First();
    }

    public async Task<DockerImage?> GetImageByName(string registryBaseUrl, string imageName)
    {
        var exceptions = new List<Exception>();
        foreach (var dockerClient in _dockerClients)
        {
            try
            {
                return await dockerClient.GetImageByName(registryBaseUrl, imageName);
            }
            catch (Exception e)
            {
                exceptions.Add(e);
            }
        }
        throw exceptions.First();
    }
}
