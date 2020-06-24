using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTrack.MVC.Models
{
    public class TicketTypeModel
    {
        [Required]
        [StringLength(maximumLength:200)]
        [Display(Name ="Ticket Type")]
        public string Name { get; set; }
    }
}