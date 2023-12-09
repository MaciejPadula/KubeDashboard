using DockerApi.DockerHttpClientStrategies;
using Microsoft.Extensions.DependencyInjection;

namespace DockerApi.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddDockerClient(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<IDockerClient>(p => new DockerHttpClient([
            new V2DockerContainerRegistryClient(p.GetRequiredService<IHttpClientFactory>()),
            new V1DockerContainerRegistryClient(p.GetRequiredService<IHttpClientFactory>())
        ]));
        return services;
    }
}
