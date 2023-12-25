namespace KubeDashboard.Model;

public readonly record struct Container(
    TaggedImage Image,
    List<int> Ports);
