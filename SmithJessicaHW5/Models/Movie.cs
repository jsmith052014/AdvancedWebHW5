using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmithJessicaHW5.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Movie Title")]
        public string Title { get; set; }

        public int Year { get; set; }

        [Range(1, 9999)]
        [DisplayName("Length of Movie")]
        public int LengthInMinutes { get; set; }

        [Required]
        [DisplayName("Movie Format")]
        public string Format { get; set; }

        [DisplayName("Genre")]
        public string Genre { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        [DisplayName("Favorited")]
        public bool IsFavorited { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }

        public virtual IEnumerable<SelectListItem> ActorSelections { get; set; }

        public virtual List<int> ActorSelectionIds { get; set; }
    }
}