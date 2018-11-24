using Application.Movies;
using Application.Movies.Queries.Search;
using MediaTracker.Home;
using MediaTracker.Main;
using Services.TMDb;
using System.Windows;

namespace MediaTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var app = new MainView();

            // TODO inject the main view model so everything downstream can be injected!
            var service = new TMDbService();
            var repo = new MovieRepository(service);
            var search = new SearchMovieQuery(repo);
            var home = new HomeViewModel(search);

            var context = new MainViewModel(home);
            app.DataContext = context;
            app.Show();
        }
    }
}