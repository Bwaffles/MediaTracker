using Application.Movies;
using Application.Movies.Queries.Dashboard;
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
            movie.WatchHistory = GetWatches(id);

            return movie;
        }

        private IEnumerable<Watch> GetWatches(int? movieId = null)
        {
            IEnumerable<Watch> watches;
            using (var connection = Connection)
            {
                connection.Open();
                watches = connection.Query<Watch>($"select wh.* from public.\"Watch\" wh where @Id is null or wh.\"MovieId\" = @Id order by wh.\"Date\" desc",
                    new { Id = movieId });
                connection.Close();
            }
            return watches;
        }

        public MovieDashboardModel GetDashboardDetails()
        {
            var movieDashboard = new MovieDashboardModel();

            TypeAdapterConfig<TMDbLib.Objects.Movies.Movie, WatchedList>
                .NewConfig()
                .Map(dest => dest.Title, src => string.Format("{0} ({1})", src.Title, (src.ReleaseDate.HasValue ? src.ReleaseDate.Value.Year.ToString() : string.Empty)))
                .Map(dest => dest.PosterUrl, src => tmdbService.GetImagePath(PosterSize.Small, src.PosterPath))
                .Map(dest => dest.MovieId, src => src.Id);

            var lastWatched = GetWatches().Take(10);
            movieDashboard.LastWatched = lastWatched.Select(lw =>
            {
                var watchedItem = tmdbService.Client.GetMovieAsync(lw.MovieId).Result.Adapt<WatchedList>();
                watchedItem.Date = lw.Date;
                return watchedItem;
            });

            return movieDashboard;
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
        { // TODO: make this look better
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