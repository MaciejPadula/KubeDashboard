using DockerApi.Extensions;
using k8s;
using KubeDashboard.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace KubeDashboard.Infrastructure;
public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
    {
        services.AddDockerClient();
        services.AddScoped<IImageRepository, DockerImageRepository>();

        services.AddScoped<IKubernetes>(p => new Kubernetes(
            KubernetesClientConfiguration.BuildDefaultConfig()));
        
        services.AddScoped<IDeploymentManager, KubernetesDeploymentManager>();
        services.AddScoped<IServiceManager, KubernetesServiceManager>();

        return services;
    }
}
