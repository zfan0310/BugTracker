using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTrack.MVC.Models
{
    public class TicketCommentModel
    {
        [Required]
        [StringLength(maximumLength: 200)]
        public string Comment { get; set; }
    }
}