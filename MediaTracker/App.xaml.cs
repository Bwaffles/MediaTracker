using MediaTracker.Main;
using System.Windows;

namespace MediaTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var app = new MainView();
            var context = new MainViewModel();
            app.DataContext = context;
            app.Show();
        }
    }
}