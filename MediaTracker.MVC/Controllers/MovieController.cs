using Application.Movies.Queries.GetMovieDetails;
using Application.Movies.Queries.Search;
using System.Linq;
using System.Web.Mvc;

namespace MediaTracker.MVC.Controllers
{
    public class MovieController : Controller
    {
        private IMovieDetailsQuery movieDetailsQuery;
        private ISearchMovieQuery searchMovieQuery;

        public MovieController(ISearchMovieQuery searchMovieQuery, IMovieDetailsQuery movieDetailsQuery)
        {
            this.movieDetailsQuery = movieDetailsQuery;
            this.searchMovieQuery = searchMovieQuery;
        }

        public ActionResult Details(int id)
        {
            return View(movieDetailsQuery.Execute(id));
        }

        public ActionResult Index(string searchString)
        {
            if (searchString == null)
                return View(Enumerable.Empty<SearchListItemModel>());

            return View(searchMovieQuery.Execute(searchString));
        }
    }
}