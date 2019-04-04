using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Movies.Commands
{
    public class WatchMovieModel
    {
        public int MovieId { get; set; }

        [Display(Name = "Comment")]
        public string Comment { get; set; }

        [Display(Name = "Date")]
        public DateTime? Date { get; set; }

        [Display(Name = "Number")]
        [Range(1, 1000)]
        public int Number { get; set; }

        [Display(Name = "Rating")]
        [Range(0, 10)]
        public decimal Rating { get; set; }
    }
}