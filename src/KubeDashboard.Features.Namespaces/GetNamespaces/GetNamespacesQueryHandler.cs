using KubeDashboard.Interfaces;
using MediatR;

namespace KubeDashboard.Features.Namespaces.GetNamespaces;

public record GetNamespacesQuery() : IRequest<List<string>>;

internal class GetNamespacesQueryHandler : IRequestHandler<GetNamespacesQuery, List<string>>
{
    private readonly INamespaceRepository _namespaceRepository;

    public GetNamespacesQueryHandler(INamespaceRepository namespaceRepository)
    {
        _namespaceRepository = namespaceRepository;
    }

    public async Task<List<string>> Handle(GetNamespacesQuery request, CancellationToken cancellationToken)
    {
        var namespaces = await _namespaceRepository.GetAllNamespaces();

        return namespaces.ToList();
    }
}
