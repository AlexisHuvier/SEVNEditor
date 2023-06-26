using SEVNLauncher.Project;
using SharpEngine;
using SharpEngine.Math;
using SharpEngine.Widget;

namespace SEVNLauncher.Scenes;

public class MainMenuScene: Scene
{
    public MainMenuScene()
    {
        AddWidget(new Label(new Vec2(600, 75), ProjectLoader.Project.ProjectInfo.Name, "basic_75"));
    }
}