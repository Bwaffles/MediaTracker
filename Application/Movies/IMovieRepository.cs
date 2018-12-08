using System.Collections.Generic;

namespace Application.Movies
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Search(string searchText);
    }
}