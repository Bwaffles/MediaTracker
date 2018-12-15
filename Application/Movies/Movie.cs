using System.Collections.Generic;

namespace Application.Movies
{
    public class Movie
    {
        public List<Genre> Genres { get; set; }
        public int Id { get; set; }
        public string Overview { get; set; }
        public string PosterUrl { get; set; }
        public string Title { get; set; }
    }
}