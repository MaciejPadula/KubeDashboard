namespace DockerApi.Model;

public class DockerImage
{
    public string Name { get; set; } = default!;
    public List<string> Tags { get; set; } = default!;
}
