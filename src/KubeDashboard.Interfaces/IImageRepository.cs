using KubeDashboard.Model;

namespace KubeDashboard.Interfaces;

public interface IImageRepository
{
    Task<IEnumerable<Image>> GetAvailableImages(string registryBaseUrl);
}
