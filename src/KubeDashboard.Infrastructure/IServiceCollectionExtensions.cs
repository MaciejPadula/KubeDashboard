using DockerApi.Extensions;
using k8s;
using KubeDashboard.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace KubeDashboard.Infrastructure;
public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDockerClient();
        services.AddScoped<IImageRepository, DockerImageRepository>();

        services.AddScoped<IKubernetes>(p => new Kubernetes(
            KubernetesClientConfiguration.BuildDefaultConfig()));
        
        services.AddScoped<IDeploymentManager, KubernetesDeploymentManager>();

        return services;
    }
}
