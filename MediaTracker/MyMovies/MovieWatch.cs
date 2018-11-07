using MediaTracker.Models;
using SQLite;

namespace MediaTracker.MyMovies
{
    public class MovieWatch : ObservableObject
    {
        private int _id;
        private int _movieId;
        private int _watchNumber;

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
    }
}