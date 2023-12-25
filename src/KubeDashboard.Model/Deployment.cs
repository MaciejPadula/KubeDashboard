namespace KubeDashboard.Model;

public record struct Deployment(
    string Name,
    int Replicas,
    int AliveReplicas,
    IEnumerable<Container> Containers,
    string Namespace);