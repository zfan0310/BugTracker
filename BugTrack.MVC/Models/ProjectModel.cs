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
        [StringLength(maximumLength: 1000)]
        [Display(Name="Project Name")]
        public string Name { get; set; }
    }
}