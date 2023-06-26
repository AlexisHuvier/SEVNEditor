using SEVNEditor;
using SharpEngine;

namespace SEVNLauncher;

internal class Program
{
    private static void Main(string[] args)
    {
        var win = new Window(1200, 800, "Sharp Engine Visual Novel Launcher", Constants.BgColor, true);

        win.Run();
    }
}