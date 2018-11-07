using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Domain
{
    public class Movie : INotifyPropertyChanged
    {
        // private string _backdropPath;
        private string _title;

        //public string BackdropPath
        //{
        //    get => _backdropPath;
        //    set
        //    {
        //        _backdropPath = value;
        //        RaisePropertyChanged();
        //    }
        //}

        //public long Budget { get; set; }

        ////public IEnumerable<Genre> Genres { get; set; }
        //public string Homepage { get; set; }

        public int Id { get; set; }

        //public string ImdbId { get; set; }

        //public string OriginalTitle { get; set; }

        //public string Overview { get; set; }

        //public double Popularity { get; set; }

        //public string PosterPath { get; set; }

        //public IEnumerable<Country> ProductionCountries { get; set; }
        //public DateTime? ReleaseDate { get; set; }

        //public long Revenue { get; set; }

        //public int? Runtime { get; set; }

        //public IEnumerable<MovieLanguage> SpokenLanguages { get; set; }
        //public string Status { get; set; }

        //public string Tagline { get; set; }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static ObservableCollection<Movie> GetMovies()
        {
            return new ObservableCollection<Movie>
            {
                new Movie{ Title = "Jurassic Park" },
                new Movie{ Title = "Martyrs" }
            };
        }

        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }

        //public IEnumerable<UserMovieWatch> Watches { get; set; }
    }
}