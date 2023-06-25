using SEVNEditor.Project;
using SharpEngine.Math;
using SharpEngine.Widget;

namespace SEVNEditor.Scene;

public class ProjectEditScene: SharpEngine.Scene
{
    public void UpdateScene(ProjectInfo info)
    {
        RemoveAllWidgets();
        
        AddWidget(new Label(new Vec2(600, 50), info.Name, "basic_30"));
    }
}