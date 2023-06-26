using SEVNEditor.Scene;
using SharpEngine.Math;
using SharpEngine.Utils;
using SharpEngine.Widget;

namespace SEVNEditor.Widgets.Page;

public class BuildPage: Widget
{
    public BuildPage() : base(new Vec2(600, 465))
    {
        AddChild(new Frame(Vec2.Zero, new Vec2(1100, 600), new Vec2(3), Color.Black, Constants.LightBgColor));
        AddChild(new Label(new Vec2(0, -250), "Build", "basic_40"));
        AddChild(new Label(new Vec2(0, 50), "Output Directory :", "basic_40"));
        var directory = AddChild(new LineInput(new Vec2(0, 100),
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "basic_35",
            new Vec2(800, 50)));
        var result = AddChild(new Label(new Vec2(0, 175), "", "basic_40"));
        result.Displayed = false;
        AddChild(new Button(new Vec2(0, 250), "Build", "basic_35")).Clicked += (_, _) =>
        {
            if (!Directory.Exists(directory.Text))
                result.Text = "This directory doesn't exist";
            else if (Directory.GetDirectories(directory.Text).Length != 0 || Directory.GetFiles(directory.Text).Length != 0)
                result.Text = "This directory isn't empty";
            else
            {
                #region Launcher Copy

                foreach (var file in Directory.GetFiles("Resource/Launcher"))
                {
                    var fileName = Path.GetFileName(file);
                    if (file.Contains("SEVNLauncher"))
                        fileName = (GetSceneAs<ProjectEditScene>()?.ProjectVn.ProjectInfo.Name ?? "Unknown") + ".exe";
                    File.Copy(file, Path.Join(directory.Text, fileName));
                }
                
                Directory.CreateDirectory(Path.Join(directory.Text, "Resource"));
                foreach (var file in Directory.GetFiles("Resource/Launcher/Resource"))
                {
                    var fileName = Path.GetFileName(file);
                    File.Copy(file, Path.Join(directory.Text, "Resource", fileName));
                }

                #endregion

                #region Project Copy
                
                Directory.CreateDirectory(Path.Join(directory.Text, "Project"));
                foreach (var file in Directory.GetFiles(Path.Join("Projects", GetSceneAs<ProjectEditScene>()?.ProjectVn.ProjectInfo.Name)))
                {
                    var fileName = Path.GetFileName(file);
                    File.Copy(file, Path.Join(directory.Text, "Project", fileName));
                }

                #endregion
                
                result.Text = "Build executed !";
            }

            result.Displayed = true;
        };
    }
}