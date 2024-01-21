using Microsoft.Extensions.DependencyInjection;

namespace KubeDashboard.Features.Namespaces;
public static class NamespacesModule
{
    public static IServiceCollection AddNamespacesModule(this IServiceCollection services)
    {
        return services;
    }
}
