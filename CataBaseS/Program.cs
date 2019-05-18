using CataBaseS.ui;
using GLib;
using Gtk;
using Application = Gtk.Application;

namespace CataBaseS
{
    class Program
    {
        public static void Main(string[] args)
        {
            Application.Init();
            Application app = new Application("dev.simo-andreev.catabase", ApplicationFlags.None);
            app.Register(Cancellable.Current);

            Window window = new AppWindow("CataBase S");
            app.AddWindow(window);

            window.SetIconFromFile("res/images/C-Sharp.png");
            
            window.Show();
            Application.Run();
        }
    }
}