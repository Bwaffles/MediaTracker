﻿using System.Web.Mvc;

namespace MediaTracker.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}