using Application.Movies.Queries.Dashboard;
using System.Web.Mvc;

namespace MediaTracker.MVC.Home
{
    public class HomeController : Controller
    {
        private IMovieDashboardQuery movieDashboardQuery;

        public HomeController(IMovieDashboardQuery movieDashboardQuery)
        {
            this.movieDashboardQuery = movieDashboardQuery;
        }

        public ActionResult Index()
        {
            return View(movieDashboardQuery.Execute());
        }
    }
}