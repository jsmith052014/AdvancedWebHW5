using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmithJessicaHW5.Models
{
    public class ActorDisplay
    {
        [Key]
        public int ActorID { get; set; }
        public bool Selected { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}