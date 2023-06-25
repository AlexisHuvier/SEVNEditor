using SEVNEditor.Manager;
using SEVNEditor.Project;
using SEVNEditor.Scene;
using SharpEngine;
using SharpEngine.Math;
using SharpEngine.Utils;
using SharpEngine.Widget;

namespace SEVNEditor.Widgets;

public class ProjectWidget: Widget
{
    public ProjectWidget(Vec2 position, ProjectInfo project) : base(position)
    {
        AddChild(new Frame(Vec2.Zero, new Vec2(1000, 200), new Vec2(5), Color.Black, Constants.LightBgColor));
        AddChild(new Label(new Vec2(0, -50), project.Name, "basic_40"));
        AddChild(new Label(new Vec2(0), $"SEVN Version : {project.SEVNVersion} - Author : {project.Author}",
            "basic_30"));
        AddChild(new Button(new Vec2(-125, 60), "Edit", "basic_30", new Vec2(200, 40))).Clicked += (_, _) =>
        {
            Scene!.Window!.IndexCurrentScene = 2;
            Scene!.Window!.GetCurrentScene<ProjectEditScene>().UpdateScene(project);
        };
        AddChild(new Button(new Vec2(125, 60), "Delete", "basic_30", new Vec2(200, 40))).Clicked += (_, _) =>
        {
            ProjectManager.RemoveProject(project.Name);
            GetSceneAs<ProjectListScene>()?.OpenScene();
        };
    }
}