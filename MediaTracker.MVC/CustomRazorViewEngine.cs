using System.Web.Mvc;

namespace MediaTracker.MVC
{
    public class CustomRazorViewEngine : RazorViewEngine
    {
        public CustomRazorViewEngine()
        {
            ViewLocationFormats = new string[]
            {
                "~/{1}/Views/{0}.cshtml",
            };

            PartialViewLocationFormats = new string[]
            {
                "~/Shared/Views/{0}.cshtml"
            };
        }
    }
}