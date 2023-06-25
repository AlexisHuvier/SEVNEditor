using System;
using SEVNEditor.Manager;
using SEVNEditor.Scene;
using SharpEngine;
using SharpEngine.Utils;

namespace SEVNEditor;

internal class Program
{
    private static void Main(string[] args)
    {
        var win = new Window(1200, 800, "Sharp Engine Visual Novel Editor", Constants.BgColor, true);

        #region Resource Loading

        win.FontManager.AddFont("basic_30", "Resource/Candy-Beans.ttf", 30);
        win.FontManager.AddFont("basic_35", "Resource/Candy-Beans.ttf", 35);
        win.FontManager.AddFont("basic_40", "Resource/Candy-Beans.ttf", 40);
        win.FontManager.AddFont("basic_75", "Resource/Candy-Beans.ttf", 75);

        #endregion
        
        
        win.AddScene(new ProjectListScene());
        win.AddScene(new ProjectAddScene());

        win.IndexCurrentScene = 0;

        win.StartCallback += (_, _) =>
        {
            ProjectManager.ReloadProjects();
            win.GetCurrentScene<ProjectListScene>().OpenScene();
        };

        win.Run();
    }
}