using DockerApi.Model;
using System.Net.Http.Json;

namespace DockerApi.DockerHttpClientStrategies;

internal abstract class DockerHttpClientBaseStrategy : IDockerClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    protected abstract string RepositoryEndpoint { get; }
    protected abstract string ImageByNameEndpoint(string imageName);

    public DockerHttpClientBaseStrategy(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<DockerImage>> GetDockerImages(string registryBaseUrl)
    {
        registryBaseUrl = registryBaseUrl.Replace("%2F", "/");
        using var httpClient = _httpClientFactory.CreateClient();

        var result = await httpClient.GetFromJsonAsync<CatalogResponse>(registryBaseUrl + RepositoryEndpoint);

        var tasks = result?
            .Repositories?
            .Select(r => GetImageByName(registryBaseUrl, r))?
            .ToList();

        if (tasks is null)
        {
            return Enumerable.Empty<DockerImage>();
        }

        await Task.WhenAll(tasks);

        return tasks
            .Select(t => t.Result)
            .Where(r => r is not null)
            .OfType<DockerImage>();
    }

    public async Task<DockerImage?> GetImageByName(string registryBaseUrl, string imageName)
    {
        using var httpClient = _httpClientFactory.CreateClient();
        var result = await httpClient.GetFromJsonAsync<DockerImage>(registryBaseUrl + ImageByNameEndpoint(imageName));
        return result;
    }
}
