using k8s.Models;
using KubeDashboard.Model;

namespace KubeDashboard.Infrastructure.Mappers;

internal static class TaggedImageMapper
{
    internal static TaggedImage ToDto(this string image)
    {
        var splitted = image.Split(':');
        return new(string.Join(":", splitted.SkipLast(1)), splitted.Last());
    }
}
