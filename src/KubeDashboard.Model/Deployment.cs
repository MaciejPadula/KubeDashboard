namespace KubeDashboard.Model;

public record struct Deployment(
    string Name,
    DeploymentType Type,
    int Replicas,
    int AliveReplicas,
    IEnumerable<TaggedImage> Images,
    string Namespace);