using Services.TMDb;
using System.Collections;
using System.Linq;

namespace Application.Movies
{
    public class MovieRepository : IMovieRepository
    {
        private ITMDbService tmdbService;

        public MovieRepository(ITMDbService tmdbService)
        {
            this.tmdbService = tmdbService;
        }

        public IEnumerable Search(string searchText)
        {
            return tmdbService.Client.SearchMovieAsync(searchText).Result.Results
                .Select(movie => movie.Title);
        }
    }
}