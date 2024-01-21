using k8s;
using k8s.Models;
using KubeDashboard.Interfaces;

namespace KubeDashboard.Infrastructure;

internal class KubernetesNamespaceRepository : INamespaceRepository
{
    private readonly IKubernetes _kubernetes;

    public KubernetesNamespaceRepository(IKubernetes kubernetes)
    {
        _kubernetes = kubernetes;
    }

    public async Task<IEnumerable<string>> GetAllNamespaces()
    {
        var namespaces = await _kubernetes.CoreV1.ListNamespaceAsync();

        return namespaces.Items
            .Select(x => x.Name());
    }
}
