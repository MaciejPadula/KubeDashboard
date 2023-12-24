using KubeDashboard.Model;

namespace KubeDashboard.Features.DeploymentsList.Api.Response;

public record class GetDeploymentsListResponse(List<Deployment> Deployments);