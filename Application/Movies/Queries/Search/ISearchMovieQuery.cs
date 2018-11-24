using System.Collections;

namespace Application.Movies.Queries.Search
{
    public interface ISearchMovieQuery
    {
        IEnumerable Execute(string searchText);
    }
}