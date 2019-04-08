using Application.Movies;
using Dapper;
using Domain;
using Mapster;
using Services.TMDb;
using System.Collections.Generic;
using System.Linq;

namespace Persistance
{
    public class MovieRepository : Repository, IMovieRepository
    {
        private ITMDbService tmdbService;

        public MovieRepository(ITMDbService tmdbService)
        {
            this.tmdbService = tmdbService;
        }

        public Movie FindById(int id)
        {
            //Get movie from TMDB API
            TypeAdapterConfig<TMDbLib.Objects.Movies.Movie, Movie>
                .NewConfig()
                .Map(dest => dest.Title, src => string.Format("{0} ({1})", src.Title, (src.ReleaseDate.HasValue ? src.ReleaseDate.Value.Year.ToString() : string.Empty)))
                .Map(dest => dest.PosterUrl, src => tmdbService.GetImagePath(PosterSize.Large, src.PosterPath))
                .Map(dest => dest.Genres, src => src.Genres.Select(g => (Genre)g.Id));
            var movie = tmdbService.Client.GetMovieAsync(id).Result.Adapt<Movie>();

            //Get WatchHistory from DB
            using (var connection = Connection)
            {
                connection.Open();
                movie.WatchHistory = connection.Query<Watch>($"select wh.* from public.\"Watch\" wh where wh.\"MovieId\" = @Id",
                    new { movie.Id });
                connection.Close();
            }

            return movie;
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

        public void WatchMovie(Watch watch)
        { // TODO: make this look better and protect against sql injection
            using (var connection = Connection)
            {
                connection.Open();

                connection.Execute($"INSERT INTO public.\"Watch\"(\"Number\", \"MovieId\", \"Rating\", \"Date\", \"Comment\") " +
                    $"VALUES(@Number, @MovieId, @Rating, @Date, @Comment);",
                    new { watch.Number, watch.MovieId, watch.Rating, watch.Date, watch.Comment });

                connection.Close();
            }
        }
    }
}