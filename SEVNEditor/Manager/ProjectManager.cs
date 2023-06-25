using System.Text.Json;
using SEVNEditor.Project;
using SharpEngine.Manager;
using SharpEngine.Utils;

namespace SEVNEditor.Manager;

public static class ProjectManager
{
    private static readonly Dictionary<string, ProjectInfo> _projects = new();

    public static Dictionary<string, ProjectInfo> GetProjects() => _projects;

    public static void RemoveProject(string name)
    {
        Directory.Delete(Path.Join("Projects", name), true);
        _projects.Remove(name);
    }

    public static bool HasProject(string name) => _projects.ContainsKey(name);

    public static void AddProject(string name, string author)
    {
        Directory.CreateDirectory(Path.Join("Projects", name));
        var project = new ProjectInfo { Name = name, Author = author, SEVNVersion = 1 };
        project.Save();
        _projects.Add(name, project);
    }

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
                var project = JsonSerializer.Deserialize<ProjectInfo>(File.ReadAllText(projectPath));
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