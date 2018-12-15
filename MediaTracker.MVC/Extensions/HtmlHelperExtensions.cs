using Application.Movies;
using System.Web;
using System.Web.Mvc;

namespace MediaTracker.MVC.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString GenreIcon(this HtmlHelper htmlHelper, Genre genre)
        {
            var genreIcon = GetGenreIcon(genre);
            if (string.IsNullOrEmpty(genreIcon))
            {
                return MvcHtmlString.Create(genre.ToString());
            }
            else
            {
                var iTag = new TagBuilder("i");
                iTag.AddCssClass($"fas fa-{genreIcon}");
                iTag.Attributes["title"] = genre.ToString();
                iTag.Attributes["style"] = "padding:0 5px";

                return MvcHtmlString.Create(iTag.ToString(TagRenderMode.Normal));
            }
        }

        private static string GetGenreIcon(Genre genre)
        {
            switch (genre)
            {
                case Genre.Action:
                    return "bomb";

                case Genre.Adventure:
                    return "globe-americas";

                case Genre.Animation:
                    break;

                case Genre.Comedy:
                    return "grin-squint-tears";

                case Genre.Crime:
                    return "user-secret";

                case Genre.Documentary:
                    return "file";

                case Genre.Drama:
                    return "theater-masks";

                case Genre.Family:
                    break;

                case Genre.Fantasy:
                    return "hat-wizard";

                case Genre.History:
                    return "landmark";

                case Genre.Horror:
                    return "ghost";

                case Genre.Music:
                    return "music";

                case Genre.Mystery:
                    return "question";

                case Genre.Romance:
                    return "heart";

                case Genre.SciFi:
                    return "atom";

                case Genre.Thriller:
                    break;

                case Genre.TVMovie:
                    return "tv";

                case Genre.War:
                    break;

                case Genre.Western:
                    return "horse";

                default:
                    break;
            }

            return "";
        }
    }
}