namespace Application.Movies.Commands.Unwatch
{
    public interface IUnwatchCommand
    {
        void Execute(int watchId);
    }
}