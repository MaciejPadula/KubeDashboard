namespace DockerApi.DockerHttpClientStrategies;

internal class V2DockerContainerRegistryClient : DockerHttpClientBaseStrategy
{
    public V2DockerContainerRegistryClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {
    }

    protected override string RepositoryEndpoint =>
        "/v2/_catalog";

    protected override string ImageByNameEndpoint(string imageName) =>
        $"/v2/{imageName}/tags/list";
}
