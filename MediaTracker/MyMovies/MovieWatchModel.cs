using System;
using MediaTracker.Models;
using SQLite;

namespace MediaTracker.MyMovies
{
    public class MovieWatchModel : ObservableObject
    {
        private int _id;
        private int _movieId;
        private string _title;
        private DateTime _watchDate;
        private int _watchNumber;
        private int _year;

        [PrimaryKey]
        public int Id
        {
            get => _id;
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public int MovieId
        {
            get => _movieId;
            set
            {
                if (value != _movieId)
                {
                    _movieId = value;
                    OnPropertyChanged("MovieId");
                }
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                if (value != _title)
                {
                    _title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        public DateTime WatchDate
        {
            get => _watchDate;
            set
            {
                if (value != _watchDate)
                {
                    _watchDate = value;
                    OnPropertyChanged("WatchDate");
                }
            }
        }

        public int WatchNumber
        {
            get => _watchNumber;
            set
            {
                if (value != _watchNumber)
                {
                    _watchNumber = value;
                    OnPropertyChanged("WatchNumber");
                }
            }
        }

        public int Year
        {
            get => _year;
            set
            {
                if (value != _year)
                {
                    _year = value;
                    OnPropertyChanged("Year");
                }
            }
        }
    }
}