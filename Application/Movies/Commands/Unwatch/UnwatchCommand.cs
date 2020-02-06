namespace Application.Movies.Commands.Unwatch
{
    public class UnwatchCommand : IUnwatchCommand
    {
        private readonly IMovieRepository movieRepository;

        public UnwatchCommand(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public void Execute(int watchId)
        {
            movieRepository.Unwatch(watchId);
        }
    }
}