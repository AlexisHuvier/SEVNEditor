using SEVNEditor.Project;
using SharpEngine.Math;
using SharpEngine.Utils;
using SharpEngine.Widget;

namespace SEVNEditor.Widgets;

public class ProjectWidget: Widget
{
    public ProjectWidget(Vec2 position, VnProject project) : base(position)
    {
        AddChild(new Frame(Vec2.Zero, new Vec2(1000, 200), new Vec2(5), Color.Black, Constants.LightBgColor));
        AddChild(new Label(new Vec2(0, -50), project.Name, "RAYLIB_DEFAULT", fontSize: 30));
        AddChild(new Label(new Vec2(0), $"SEVN Version : {project.SEVNVersion} - Author : {project.Author}",
            "RAYLIB_DEFAULT", fontSize: 28));
        AddChild(new Button(new Vec2(-125, 60), "Editer", "RAYLIB_DEFAULT", new Vec2(200, 40), fontSize: 20));
        AddChild(new Button(new Vec2(125, 60), "Supprimer", "RAYLIB_DEFAULT", new Vec2(200, 40), fontSize: 20));
    }
}