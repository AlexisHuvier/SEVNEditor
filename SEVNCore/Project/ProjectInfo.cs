using System.Text.Json;

namespace SEVNCore.Project;

public class ProjectInfo
{
    public string Name { get; set; }
    public string Author { get; set; }
    public int SEVNVersion { get; set; }

    public void Save()
    {
        File.WriteAllText(Path.Join("Projects", Name, "project.json"), JsonSerializer.Serialize(this));
    }
}