using KubeDashboard.Model;

namespace KubeDashboard.Features.CreateDeployment.Api.Request;

public record class CreateRequest(string Name, DeploymentType Type, IEnumerable<TaggedImage> Images, int Replicas, string Namespace = "default");
