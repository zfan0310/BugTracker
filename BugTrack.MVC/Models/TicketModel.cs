using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTrack.MVC.Models
{
    public class TicketModel
    {
        [Required]
        [StringLength(maximumLength: 200)]
        [Display(Name = "Ticket title")]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 1000)]
        [Display(Name = "Ticket Discribption")]
        public string Description { get; set; }

    }
}