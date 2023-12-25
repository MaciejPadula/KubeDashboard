using KubeDashboard.Model;

namespace KubeDashboard.Features.CreateDeployment.Api.Request;

public record class CreateRequest(string Name, IEnumerable<Container> Containers, int Replicas, string Namespace = "default");
