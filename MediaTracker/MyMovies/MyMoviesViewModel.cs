using MediaTracker.Common;
using MediaTracker.Models;
using System.Windows.Input;

namespace MediaTracker.MyMovies
{
    public class MyMoviesViewModel : ObservableObject, IPageViewModel
    {
        private ICommand _getProductCommand;
        private int _movieId;
        private MovieWatch _movieWatch;
        private ICommand _saveMovieWatchCommand;

        public MovieWatch CurrentMovieWatch
        {
            get { return _movieWatch; }
            set
            {
                if (value != _movieWatch)
                {
                    _movieWatch = value;
                    OnPropertyChanged("CurrentMovieWatch");
                }
            }
        }

        public ICommand GetMovieWatchCommand
        {
            get
            {
                if (_getProductCommand == null)
                {
                    _getProductCommand = new RelayCommand(
                        param => GetMovieWatch(),
                        param => MovieId > 0
                    );
                }
                return _getProductCommand;
            }
        }

        public int MovieId
        {
            get { return _movieId; }
            set
            {
                if (value != _movieId)
                {
                    _movieId = value;
                    OnPropertyChanged("MovieId");
                }
            }
        }

        public string Name
        {
            get { return "My Movies"; }
        }

        public ICommand SaveMovieWatchCommand
        {
            get
            {
                if (_saveMovieWatchCommand == null)
                {
                    _saveMovieWatchCommand = new RelayCommand(
                        param => SaveProduct(),
                        param => (CurrentMovieWatch != null)
                    );
                }
                return _saveMovieWatchCommand;
            }
        }

        public MyMoviesViewModel()
        {
            //var tmdb = new TMDbService();

            //string sql = "CREATE TABLE movies (title VARCHAR(256))";
            //var db = new Test();
            //var watches = db.m_dbConnection.Query<MovieWatch>("select * from MovieWatch");

            //MovieGrid.ItemsSource = watches.Select(w => new { tmdb.GetMovie(w.MovieId).Title, w.WatchNumber });
        }

        private void GetMovieWatch()
        {
            // You should get the product from the database
            // but for now we'll just return a new object
            var mw = new MovieWatch();
            mw.MovieId = MovieId;
            mw.WatchNumber = 1;
            mw.Id = 1;
            CurrentMovieWatch = mw;
        }

        private void SaveProduct()
        {
            // You would implement your Product save here
        }
    }
}