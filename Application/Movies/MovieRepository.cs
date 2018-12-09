using Services.TMDb;
using System.Collections.Generic;
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

        public IEnumerable<Movie> Search(string searchText)
        {
            return tmdbService.Client.SearchMovieAsync(searchText).Result.Results
                .Select(movie => new Movie
                {
                    Title = string.Format($"{movie.Title} ({movie.ReleaseDate?.Year})"),
                    Id = movie.Id
                });
        }
    }
}