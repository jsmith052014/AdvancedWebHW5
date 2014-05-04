using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SmithJessicaHW5.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Middle Initial")]
        public string MiddleInitial { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public virtual List<Movie> Movies { get; set; }
    }
}