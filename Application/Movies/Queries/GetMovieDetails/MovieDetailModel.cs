using System.Collections.Generic;

namespace Application.Movies.Queries.GetMovieDetails
{
    public class MovieDetailModel
    {
        public List<Genre> Genres { get; set; }
        public string Overview { get; set; }
        public string PosterUrl { get; set; }
        public string Title { get; set; }
    }
}