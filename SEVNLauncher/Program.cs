using SEVNEditor;
using SEVNLauncher.Project;
using SEVNLauncher.Scenes;
using SharpEngine;

namespace SEVNLauncher;

internal class Program
{
    private static void Main(string[] args)
    {
        ProjectLoader.LoadProject();
        
        var win = new Window(1200, 800, ProjectLoader.Project.ProjectInfo.Name, Constants.BgColor, true);
        
        #region Resource Loading

        win.FontManager.AddFont("basic_30", "Resource/Candy-Beans.ttf", 30);
        win.FontManager.AddFont("basic_35", "Resource/Candy-Beans.ttf", 35);
        win.FontManager.AddFont("basic_40", "Resource/Candy-Beans.ttf", 40);
        win.FontManager.AddFont("basic_75", "Resource/Candy-Beans.ttf", 75);

        #endregion
        
        win.AddScene(new MainMenuScene());

        win.Run();
    }
}