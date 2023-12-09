namespace DockerApi.Model;

internal class CatalogResponse
{
    public IEnumerable<string> Repositories { get; set; } = default!;
}
