using System.Collections.Generic;
using System.Linq;

namespace Application.Movies.Queries.Search
{
    public class SearchMovieQuery : ISearchMovieQuery
    {
        private IMovieRepository movieRepository;

        public SearchMovieQuery(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public IEnumerable<SearchListItemModel> Execute(string searchText)
        {
            return movieRepository
                .Search(searchText)
                .Select(m => new SearchListItemModel
                {
                    Title = m.Title,
                    Id = m.Id
                });
        }
    }
}