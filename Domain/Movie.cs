using System.Collections.Generic;

namespace Domain
{
    public class Movie
    {
        public List<Genre> Genres { get; set; }
        public int Id { get; set; }
        public string Overview { get; set; }
        public string PosterUrl { get; set; }
        public string Title { get; set; }
        public IEnumerable<WatchHistory> WatchHistory { get; set; }
    }
}