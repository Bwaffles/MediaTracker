using System.Collections;

namespace Application.Movies.Queries.Search
{
    public class SearchMovieQuery : ISearchMovieQuery
    {
        private IMovieRepository movieRepository;

        public SearchMovieQuery(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public IEnumerable Execute(string searchText)
        {
            return movieRepository.Search(searchText);
        }
    }
}