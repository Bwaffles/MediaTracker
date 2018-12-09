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

        IEnumerable<Movie> Search(string searchText);
    }
}