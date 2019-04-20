using System.Collections.Generic;

namespace Application.Movies.Queries.Dashboard
{
    public class WatchedList
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string PosterUrl { get; set; }
        public int MovieId { get; set; }
    }
    public class MovieDashboardModel
    {
        public IEnumerable<WatchedList> LastWatched { get; set; }
    }
}
