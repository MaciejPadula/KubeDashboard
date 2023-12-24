using k8s.Models;
using KubeDashboard.Model;

namespace KubeDashboard.Infrastructure.Mappers;

internal static class DeploymentMapper
{
    internal static Deployment ToDto(this V1Deployment deployment) =>
        new(deployment.Name(),
            DeploymentType.CronJob,
            deployment.Spec.Replicas ?? 0,
            deployment.Status.ReadyReplicas ?? 0,
            deployment.Spec.Template.Spec.Containers.Select(c => c.ToDto()),
            deployment.Namespace());

    internal static V1Deployment ToIto(this Deployment deployment) =>
        new()
        {
            Metadata = new()
            {
                Name = deployment.Name
            },
            Status = new V1DeploymentStatus()
            {
                Replicas = deployment.Replicas
            },
            Spec = new()
            {
                Selector = new V1LabelSelector()
                {
                    MatchLabels = new Dictionary<string, string>
                    {
                        { "app", deployment.Name }
                    }
                },
                Replicas = deployment.Replicas,
                Template = new()
                {
                    Spec = new()
                    {
                        Containers = deployment.Images
                                .Select(x => x.ToIto())
                                .ToList()
                    },
                    Metadata = new()
                    {
                        Labels = new Dictionary<string, string>
                        {
                            { "app", deployment.Name }
                        }
                    }
                }
            }
        };
}
