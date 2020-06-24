using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTrack.MVC.Models
{
    public class RoleModel
    {
        [Required]
        [StringLength(maximumLength: 200)]
        [Display(Name = "Priority Name")]
        public string Name { get; set; }
    }
}