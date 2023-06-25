using SEVNEditor.Manager;
using SEVNEditor.Widgets;
using SharpEngine.Math;
using SharpEngine.Widget;

namespace SEVNEditor.Scene;

public class ProjectListScene: SharpEngine.Scene
{
    private readonly List<ProjectWidget> _projectWidgets = new();
    private int _indexStart;

    public ProjectListScene()
    {
        AddWidget(new Label(new Vec2(600, 75), "Sharp Engine Visual Novel Editor", "basic_75"));

        AddWidget(
                new Button(new Vec2(600, 700), "Add a Project", "basic_35", new Vec2(700, 60))).Clicked +=
            (_, _) => Window!.IndexCurrentScene = 1;
        
        AddWidget(
            new Button(new Vec2(1150, 390), ">", "basic_35", new Vec2(50))).Clicked += (_, _) =>
        {
            _indexStart += 2;
            var projects = ProjectManager.GetProjects();
            if (_indexStart >= projects.Count)
                _indexStart -= 2;
            UpdateProjects();
        };
        
        AddWidget(
            new Button(new Vec2(50, 390), "<", "basic_35", new Vec2(50))).Clicked += (_, _) =>
        {
            _indexStart -= 2;
            if (_indexStart < 0)
                _indexStart = 0;
            UpdateProjects();
        };
    }
    
    public void UpdateProjects()
    {
        foreach (var projectWidget in _projectWidgets)
            RemoveWidget(projectWidget);
        
        _projectWidgets.Clear();

        var projects = ProjectManager.GetProjects();
        for(var i = _indexStart; i < projects.Count && i < _indexStart + 2; i++)
            _projectWidgets.Add(AddWidget(new ProjectWidget(new Vec2(600, 260 + 260 * (i % 2)), projects.Values.ToList()[i])));
    }

    public override void OpenScene()
    {
        base.OpenScene();

        _indexStart = 0;
        UpdateProjects();
    }
}