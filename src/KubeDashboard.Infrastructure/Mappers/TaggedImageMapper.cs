﻿using k8s.Models;
using KubeDashboard.Model;

namespace KubeDashboard.Infrastructure.Mappers;

internal static class TaggedImageMapper
{
    internal static TaggedImage ToDto(this string image)
    {
        var splitted = image.Split(':');
        return new(string.Join(":", splitted.SkipLast(1)), splitted.Last());
    }

    internal static TaggedImage ToDto(this V1Container container) =>
        container.Image.ToDto();

    internal static V1Container ToIto(this TaggedImage image) =>
        new()
        {
            Name = "teststsas",
            Image = $"{image.Name}:{image.Tag}",
            ImagePullPolicy = "Always"
        };
}
