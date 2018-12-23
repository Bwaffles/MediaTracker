using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Application.Movies.Queries.GetMovieDetails
{
    public class MovieDetailModel
    {
        private IEnumerable<WatchHistoryModel> _watchHistory;

        public List<Genre> Genres { get; set; }

        public int Id { get; set; }

        public string Overview { get; set; }

        public string PosterUrl { get; set; }

        public string Title { get; set; }

        public bool Watched
        {
            get { return WatchHistory.Any(); }
        }

        public IEnumerable<WatchHistoryModel> WatchHistory
        {
            get
            {
                return _watchHistory ?? Enumerable.Empty<WatchHistoryModel>();
            }
            set => _watchHistory = value;
        }
    }
}