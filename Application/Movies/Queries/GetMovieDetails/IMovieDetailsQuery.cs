namespace Application.Movies.Queries.GetMovieDetails
{
    public interface IMovieDetailsQuery
    {
        MovieDetailModel Execute(int id);
    }
}