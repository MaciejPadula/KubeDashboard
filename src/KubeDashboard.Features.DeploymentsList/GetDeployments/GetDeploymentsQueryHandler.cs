using KubeDashboard.Interfaces;
using KubeDashboard.Model;
using MediatR;

namespace KubeDashboard.Features.DeploymentsList.GetDeployments;

public record class GetDeploymentsQuery(string Namespace) : IRequest<List<Deployment>>;

internal class GetDeploymentsQueryHandler : IRequestHandler<GetDeploymentsQuery, List<Deployment>>
{
    private readonly IDeploymentManager _deploymentManager;

    public GetDeploymentsQueryHandler(IDeploymentManager deploymentManager)
    {
        _deploymentManager = deploymentManager;
    }

    public async Task<List<Deployment>> Handle(GetDeploymentsQuery request, CancellationToken cancellationToken)
    {
        var result = await _deploymentManager.GetDeploys(request.Namespace);
        return result.ToList();
    }
}
