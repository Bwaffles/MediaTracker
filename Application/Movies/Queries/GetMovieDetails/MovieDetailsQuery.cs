using System.Linq;

namespace Application.Movies.Queries.GetMovieDetails
{
    public class MovieDetailsQuery : IMovieDetailsQuery
    {
        private IMovieRepository movieRepository;

        public MovieDetailsQuery(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public MovieDetailModel Execute(int id)
        {
            var movie = movieRepository.FindById(id);
            return new MovieDetailModel
            {
                Title = movie.Title,
                Overview = movie.Overview,
                PosterUrl = movie.PosterUrl,
                Genres = movie.Genres,
                Id = movie.Id,
                WatchHistory = movie.WatchHistory.Select(wh => new WatchModel
                {
                    Id = wh.Id,
                    Number = wh.Number,
                    WatchedOn = wh.Date.ToString("dddd MMMM dd, yyyy"),
                    Rating = wh.Rating.ToString(),
                    Comment = wh.Comment,
                })
            };
        }
    }
}