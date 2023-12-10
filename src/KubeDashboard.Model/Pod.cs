namespace KubeDashboard.Model;

public record struct Pod(string Name, string Status, bool IsAlive);
