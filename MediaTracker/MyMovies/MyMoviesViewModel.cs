using MediaTracker.Common;
using MediaTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MediaTracker.MyMovies
{
    public class MyMoviesViewModel : ObservableObject, IPageViewModel
    {
        private ICommand _getProductCommand;
        private int _movieId;
        private MovieWatchModel _movieWatch;
        private ICommand _saveMovieWatchCommand;

        public MovieWatchModel CurrentMovieWatch
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

        /// <summary>
        /// Gets a list of movie watches.
        /// </summary>
        public IEnumerable<MovieWatchModel> MyMovies
        {
            get
            {
                // TODO: get the list from the database. Sorted by watch date desc.
                return new List<MovieWatchModel>
                {
                    new MovieWatchModel{ Id=1, MovieId=329, WatchNumber=30, WatchDate=new DateTime(2018,6,15), Title="Jurassic Park", Year=1993},
                    new MovieWatchModel{ Id=1, MovieId=329, WatchNumber=1, WatchDate=new DateTime(2018,11,3), Title="The Kindergarden Teacher", Year=2018},
                    new MovieWatchModel{ Id=2, MovieId=424139, WatchNumber=1, WatchDate=new DateTime(2018,10,31), Title="Halloween", Year=2018}
                }.OrderByDescending(mw => mw.WatchDate);
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
            var mw = new MovieWatchModel();
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