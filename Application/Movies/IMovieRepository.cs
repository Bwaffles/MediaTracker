using Application.Movies.Queries.Dashboard;
using Domain;
using System.Collections.Generic;

namespace Application.Movies
{
    public interface IMovieRepository
    {
        /// <summary>
        /// Returns a movie for the <paramref name="id"/> if it exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Movie FindById(int id);

        MovieDashboardModel GetDashboardDetails();

        IEnumerable<Movie> Search(string searchText);

        /// <summary>
        /// Unwatch a movie.
        /// </summary>
        /// <param name="watchId">The id of the watch to remove.</param>
        void Unwatch(int watchId);

        /// <summary>
        /// Watch a movie.
        /// </summary>
        /// <param name="watch">The watch details.</param>
        void WatchMovie(Watch watch);
    }
}