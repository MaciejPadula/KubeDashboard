using KubeDashboard.Model;

namespace KubeDashboard.Features.CreateDeployment.Api.Request;

public record CreateServiceRequest(
    string DeploymentName,
    string ServiceName,
    LoadBalancerConfiguration Configuration,
    string Namespace = "default");
