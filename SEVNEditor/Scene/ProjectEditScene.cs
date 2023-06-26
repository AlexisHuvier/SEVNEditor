using SEVNEditor.Project;
using SharpEngine.Math;
using SharpEngine.Widget;

namespace SEVNEditor.Scene;

public class ProjectEditScene: SharpEngine.Scene
{
    public void UpdateScene(ProjectInfo info)
    {
        RemoveAllWidgets();

        AddWidget(new Label(new Vec2(600, 40), info.Name, "basic_75"));

        AddWidget(new Button(new Vec2(250, 110), "Characters", "basic_40", new Vec2(300, 40)));
        AddWidget(new Button(new Vec2(600, 110), "Scripts", "basic_40", new Vec2(300, 40)));
        AddWidget(new Button(new Vec2(950, 110), "Parameters", "basic_40", new Vec2(300, 40)));
    }
}