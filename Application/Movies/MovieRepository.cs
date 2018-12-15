using Mapster;
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
            TypeAdapterConfig<TMDbLib.Objects.Movies.Movie, Movie>
                .NewConfig()
                .Map(dest => dest.Title, src => string.Format("{0} ({1})", src.Title, (src.ReleaseDate.HasValue ? src.ReleaseDate.Value.Year.ToString() : string.Empty)))
                .Map(dest => dest.PosterUrl, src => tmdbService.GetImagePath(PosterSize.Large, src.PosterPath))
                .Map(dest => dest.Overview, src => src.Overview)
                .Map(dest => dest.Genres, src => src.Genres.Select(g => (Genre)g.Id));
            return movie.Adapt<Movie>();
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