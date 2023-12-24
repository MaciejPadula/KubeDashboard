namespace KubeDashboard.Features.DeploymentControl.Api.Request;

public record class AddEnvironmentVariables(
    string DeploymentName,
    Dictionary<string, string> EnvironmentVariables,
    string Namespace = "default");
