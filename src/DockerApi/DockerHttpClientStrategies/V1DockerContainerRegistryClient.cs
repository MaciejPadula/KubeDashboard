namespace DockerApi.DockerHttpClientStrategies;

internal class V1DockerContainerRegistryClient : DockerHttpClientBaseStrategy
{
    public V1DockerContainerRegistryClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {
    }

    protected override string RepositoryEndpoint =>
        "/v1/_catalog";

    protected override string ImageByNameEndpoint(string imageName) =>
        $"/v1/{imageName}/tags/list";
}
