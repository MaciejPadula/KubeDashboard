namespace KubeDashboard.Interfaces;

public interface INamespaceRepository
{
    Task<IEnumerable<string>> GetAllNamespaces();
}
