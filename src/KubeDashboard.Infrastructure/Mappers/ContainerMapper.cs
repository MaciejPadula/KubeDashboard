using k8s.Models;
using KubeDashboard.Model;

namespace KubeDashboard.Infrastructure.Mappers;

internal static class ContainerMapper
{
    internal static Container ToDto(this V1Container container) =>
        new(container.Image.ToDto(), container.Ports?.Select(p => p.ContainerPort).ToList() ?? []);

    internal static V1Container ToIto(this Container container) =>
        new()
        {
            Name = "teststsas",
            Image = $"{container.Image.Name}:{container.Image.Tag}",
            ImagePullPolicy = "Always",
            Ports = container.Ports?.Select(p => new V1ContainerPort { ContainerPort = p }).ToList() ?? []
        };
}
