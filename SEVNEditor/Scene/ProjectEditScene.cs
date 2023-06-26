using SEVNCore.Project;
using SEVNEditor.Widgets.Page;
using SharpEngine.Math;
using SharpEngine.Widget;

namespace SEVNEditor.Scene;

public class ProjectEditScene: SharpEngine.Scene
{
    public ProjectVn ProjectVn;
    
    private Button _characters;
    private Button _scripts;
    private Button _parameters;
    private Button _build;
    private CharactersPage _charactersPage;
    private ScriptsPage _scriptsPage;
    private ParametersPage _parametersPage;
    private BuildPage _buildPage;
    
    public void UpdateScene(ProjectInfo info)
    {
        RemoveAllWidgets();

        ProjectVn = new ProjectVn(Path.Join("Projects", info.Name));

        AddWidget(new Label(new Vec2(600, 40), info.Name, "basic_75"));

        _characters = AddWidget(new Button(new Vec2(150, 110), "Characters", "basic_40", new Vec2(250, 40)));
        _scripts = AddWidget(new Button(new Vec2(450, 110), "Scripts", "basic_40", new Vec2(250, 40)));
        _parameters = AddWidget(new Button(new Vec2(750, 110), "Parameters", "basic_40", new Vec2(250, 40)));
        _build = AddWidget(new Button(new Vec2(1050, 110), "Build", "basic_40", new Vec2(250, 40)));

        _charactersPage = AddWidget(new CharactersPage());
        _scriptsPage = AddWidget(new ScriptsPage());
        _parametersPage = AddWidget(new ParametersPage());
        _buildPage = AddWidget(new BuildPage());

        _characters.Clicked += (_, _) => Clicked(true, false, false, false);
        _scripts.Clicked += (_, _) => Clicked(false, true, false, false);
        _parameters.Clicked += (_, _) => Clicked(false, false, true, false);
        _build.Clicked += (_, _) => Clicked(false, false, false, true);
        
        Clicked(true, false, false, false);
    }

    private void Clicked(bool characters, bool scripts, bool parameters, bool build)
    {
        _characters.Active = !characters;
        _scripts.Active = !scripts;
        _parameters.Active = !parameters;
        _build.Active = !build;

        _charactersPage.Displayed = characters;
        _scriptsPage.Displayed = scripts;
        _parametersPage.Displayed = parameters;
        _buildPage.Displayed = build;
    }
}