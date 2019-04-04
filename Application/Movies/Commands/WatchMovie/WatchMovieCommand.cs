using Domain;

namespace Application.Movies.Commands.WatchMovie
{
    public class WatchMovieCommand : IWatchMovieCommand
    {
        private readonly IMovieRepository movieRepository;

        public WatchMovieCommand(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public void Execute(WatchMovieModel model)
        {
            var watch = new Watch
            {
                MovieId = model.MovieId,
                Comment = model.Comment,
                Date = model.Date,
                Number = model.Number,
                Rating = model.Rating
            };

            movieRepository.WatchMovie(watch);
        }
    }
}
