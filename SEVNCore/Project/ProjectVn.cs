using System.Text.Json;

namespace SEVNCore.Project;

public class ProjectVn
{
    public ProjectInfo ProjectInfo { get; set; }

    public ProjectVn(string directory)
    {
        var projectPath = Path.Join(directory, "project.json");
        if (File.Exists(projectPath))
        {
            var project = JsonSerializer.Deserialize<ProjectInfo>(File.ReadAllText(projectPath));
            if (project != null)
                ProjectInfo = project;
            else
                throw new NullReferenceException("Project doesn't have project.json");
        }
        else
            throw new NullReferenceException("Project doesn't have project.json");
    }
}