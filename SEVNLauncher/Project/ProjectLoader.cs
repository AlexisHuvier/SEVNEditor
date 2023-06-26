using SEVNCore.Project;
using SharpEngine.Manager;
using SharpEngine.Utils;

namespace SEVNLauncher.Project;

public static class ProjectLoader
{
    public static ProjectVn Project;
    
    public static void LoadProject()
    {
        if (!Directory.Exists("Project"))
        {
            DebugManager.Log(LogLevel.LogFatal, "PROJECT: No project founded !");
            throw new NullReferenceException("Project doesn't exists");
        }
        DebugManager.Log(LogLevel.LogDebug, "PROJECT: Load Project...");
        Project = new ProjectVn("Project");
    }
}