using Application.Movies.Queries.Search;
using System.Linq;
using System.Web.Mvc;

namespace MediaTracker.MVC.Controllers
{
    public class MovieController : Controller
    {
        private ISearchMovieQuery searchMovieQuery;

        public MovieController(ISearchMovieQuery searchMovieQuery)
        {
            this.searchMovieQuery = searchMovieQuery;
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Index(string searchString)
        {
            if (searchString == null)
                return View(Enumerable.Empty<SearchListItemModel>());

            return View(searchMovieQuery.Execute(searchString));
        }
    }
}