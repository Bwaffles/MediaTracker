using Application.Movies.Commands;
using Application.Movies.Commands.WatchMovie;
using Application.Movies.Queries.GetMovieDetails;
using Application.Movies.Queries.Search;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MediaTracker.MVC.Controllers
{
    [RoutePrefix("movies")]
    public class MoviesController : Controller
    {
        private IMovieDetailsQuery movieDetailsQuery;
        private ISearchMovieQuery searchMovieQuery;
        private readonly IWatchMovieCommand watchMovieCommand;

        public MoviesController(ISearchMovieQuery searchMovieQuery, IMovieDetailsQuery movieDetailsQuery, IWatchMovieCommand watchMovieCommand)
        {
            this.movieDetailsQuery = movieDetailsQuery;
            this.searchMovieQuery = searchMovieQuery;
            this.watchMovieCommand = watchMovieCommand;
        }

        [Route("{id:int}")]
        public ActionResult Details(int id)
        {
            return View(movieDetailsQuery.Execute(id));
        }

        [Route("")]
        public ActionResult Index(string searchString)
        {
            if (searchString == null)
                return View(Enumerable.Empty<SearchListItemModel>());

            return View(searchMovieQuery.Execute(searchString));
        }

        [Route("watch")]
        public ActionResult Watch(int movieId)
        {
            // TODO: Get last watch for this movie from DB -- next number
            var model = new WatchMovieModel
            {
                MovieId = movieId,
                Number = 1,
                Date = DateTime.Today
            };
            return View(model);
        }

        [Route("watch")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Watch(WatchMovieModel model)
        {
            if (ModelState.IsValid)
            {
                watchMovieCommand.Execute(model);
                return Json(new { redirectToUrl = Url.Action("details", "movies", new { id = model.MovieId }) });
            }

            return View(model);
        }
    }
}