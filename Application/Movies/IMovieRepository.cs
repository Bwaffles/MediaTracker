using System.Collections;

namespace Application.Movies
{
    public interface IMovieRepository
    {
        IEnumerable Search(string searchText);
    }
}