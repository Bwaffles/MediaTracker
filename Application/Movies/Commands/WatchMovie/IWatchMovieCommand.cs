namespace Application.Movies.Commands.WatchMovie
{
    public interface IWatchMovieCommand
    {
        void Execute(WatchMovieModel model);
    }
}
