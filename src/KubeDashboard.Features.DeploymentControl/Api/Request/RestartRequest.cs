namespace KubeDashboard.Features.DeploymentControl.Api.Request;

public record class RestartRequest(string DeploymentName, string Namespace = "default");