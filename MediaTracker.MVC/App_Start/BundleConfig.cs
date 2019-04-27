﻿using System.Web.Optimization;

namespace MediaTracker.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/semantic/dist/semantic.min.js",
                      "~/Scripts/jquery.barrating.min.js",
                      "~/Scripts/jquery.rateyo.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css",
                      "~/Content/font-awesome.min.css",
                      "~/semantic/dist/semantic.min.css",
                      "~/Content/bars-movie.css",
                      "~/Content/jquery.rateyo.css"));
        }
    }
}