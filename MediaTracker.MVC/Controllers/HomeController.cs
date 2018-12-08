using Application.Movies;
using Application.Movies.Queries.Search;
using Services.TMDb;
using System.Linq;
using System.Web.Mvc;

namespace MediaTracker.MVC.Controllers
{
    public class HomeController : Controller
    {
        private ISearchMovieQuery searchMovieQuery;

        public HomeController()
        {
            this.searchMovieQuery = new SearchMovieQuery(new MovieRepository(new TMDbService()));
        }

        public ActionResult Index(string searchString)
        {
            if (searchString == null)
                return View(Enumerable.Empty<SearchListItemModel>());

            return View(searchMovieQuery.Execute(searchString));
        }
    }
}