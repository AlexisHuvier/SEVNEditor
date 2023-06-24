using System.Text.Json;
using SEVNEditor.Project;
using SharpEngine.Manager;
using SharpEngine.Utils;

namespace SEVNEditor.Manager;

public static class ProjectManager
{
    private static readonly Dictionary<string, VnProject> _projects = new();

    public static Dictionary<string, VnProject> GetProjects() => _projects;

    public static void ReloadProjects()
    {
        _projects.Clear();

        if (!Directory.Exists("Projects"))
            Directory.CreateDirectory("Projects");
        
        DebugManager.Log(LogLevel.LogDebug, $"PROJECT: Reload Projects...");
        foreach (var directory in Directory.GetDirectories("Projects"))
        {
            var projectPath = Path.Join(directory, "project.json");
            if (File.Exists(projectPath))
            {
                var project = JsonSerializer.Deserialize<VnProject>(File.ReadAllText(projectPath));
                if (project != null)
                {
                    DebugManager.Log(LogLevel.LogDebug, $"PROJECT: New detected project : {project.Name}");
                    _projects.Add(project.Name, project);
                }
            }
        }

        DebugManager.Log(LogLevel.LogDebug, $"PROJECT: Projects reloaded !");
    }
}