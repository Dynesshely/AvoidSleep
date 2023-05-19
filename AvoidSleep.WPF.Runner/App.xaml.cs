using KitX.Contract.CSharp;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Windows;

namespace AvoidSleep.WPF.Runner;

public partial class App : Application
{
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        var dirPath = Path.GetFullPath(".");
        var fileName = "AvoidSleep.WPF.dll";

        var catalog = new DirectoryCatalog(dirPath, fileName);

        var container = new CompositionContainer(catalog);

        var sub = container.GetExportedValues<IIdentityInterface>();

        foreach (var item in sub)
        {
            var controller = item.GetController();

            controller.Start();

            break;
        }
    }
}
