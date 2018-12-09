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
                PosterUrl = movie.PosterUrl
            };
        }
    }
}