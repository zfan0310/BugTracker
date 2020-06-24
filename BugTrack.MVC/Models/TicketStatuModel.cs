using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTrack.MVC.Models
{
    public class TicketStatuModel
    {
        [Required]
        [StringLength(maximumLength: 200)]
        [Display(Name="Status Name")]
        public string Name { get; set; }
    }
}