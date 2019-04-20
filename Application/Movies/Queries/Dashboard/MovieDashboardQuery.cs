namespace Application.Movies.Queries.Dashboard
{
    public class MovieDashboardQuery : IMovieDashboardQuery
    {
        private readonly IMovieRepository movieRepository;

        public MovieDashboardQuery(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public MovieDashboardModel Execute()
        {
            return movieRepository.GetDashboardDetails();
        }
    }
}
