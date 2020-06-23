using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTrack.MVC.Models
{
    public class ProjectModel
    {
        [Required]
        [MaxLength(5000)]
        public string Name { get; set; }
    }
}