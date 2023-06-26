using SharpEngine.Math;
using SharpEngine.Utils;
using SharpEngine.Widget;

namespace SEVNEditor.Widgets.Page;

public class ParametersPage: Widget
{
    public ParametersPage() : base(new Vec2(600, 465))
    {
        AddChild(new Frame(Vec2.Zero, new Vec2(1100, 600), new Vec2(3), Color.Black, Constants.LightBgColor));
        AddChild(new Label(new Vec2(0, -250), "Parameters", "basic_35"));
    }
}