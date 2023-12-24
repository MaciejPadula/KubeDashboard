using KubeDashboard.Model;

namespace KubeDashboard.Features.DeploymentsList.Api.Response;

public record GetDeploymentPodsResponse(List<Pod> AlivePods, List<Pod> DeadPods);
