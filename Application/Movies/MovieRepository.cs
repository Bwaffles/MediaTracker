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

        public Movie FindById(int id)
        {
            var movie = tmdbService.Client.GetMovieAsync(id).Result;
            return new Movie
            {
                Title = movie.Title
            };
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