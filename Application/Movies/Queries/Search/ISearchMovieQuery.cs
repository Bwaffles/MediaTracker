using System.Collections.Generic;

namespace Application.Movies.Queries.Search
{
    public interface ISearchMovieQuery
    {
        IEnumerable<SearchListItemModel> Execute(string searchText);
    }
}