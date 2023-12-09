namespace KubeDashboard.Model;

public record struct Deployment(string Name, DeploymentType Type, int Replicas, IEnumerable<TaggedImage> Images, string Namespace);