using Microsoft.Extensions.DependencyInjection;

namespace KubeDashboard.Features.DeploymentsList;

public static class DeploymentsListModule
{
    public static IServiceCollection AddDeploymentsListModule(this IServiceCollection services)
    {
        return services;
    }
}
