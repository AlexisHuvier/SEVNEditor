using SEVNEditor.Manager;
using SharpEngine.Math;
using SharpEngine.Utils;
using SharpEngine.Widget;

namespace SEVNEditor.Scene;

public class ProjectAddScene: SharpEngine.Scene
{
    public ProjectAddScene()
    {
        AddWidget(new Label(new Vec2(600, 75), "Add a Project", "basic_75"));

        AddWidget(new Label(new Vec2(600, 225), "Project Name :", "basic_40"));
        var nameInput = AddWidget(new LineInput(new Vec2(600, 300), "", "basic_35"));

        AddWidget(new Label(new Vec2(600, 400), "Project Author :", "basic_40"));
        var authorInput = AddWidget(new LineInput(new Vec2(600, 475), "", "basic_35"));

        var alreadyExists = AddWidget(new Label(new Vec2(600, 550), "This project already exists !", "basic_40", Color.Red));
        alreadyExists.Displayed = false;
        
        AddWidget(
            new Button(new Vec2(800, 700), "Ajouter", "basic_35", new Vec2(350, 50))).Clicked +=
            (_, _) =>
            {
                alreadyExists.Displayed = false;
                if (!ProjectManager.HasProject(nameInput.Text))
                {
                    ProjectManager.AddProject(nameInput.Text, authorInput.Text);
                    Window!.IndexCurrentScene = 0;
                }
                else
                    alreadyExists.Displayed = true;
            };

        AddWidget(
                new Button(new Vec2(400, 700), "Annuler", "basic_35", new Vec2(350, 50))).Clicked +=
            (_, _) => Window!.IndexCurrentScene = 0;
    }
}