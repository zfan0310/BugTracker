using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADKZ_BugTrack.Models
{
    public class Projects
    {
        public Projects()
        {
            this.Tickets = new HashSet<Tickets>();
            this.ProjectUsers = new HashSet<ProjectUsers>();
        }
        public Guid Id { get; set; } = new Guid();
        [DataType(DataType.Text)]
        public string Name { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }
        public virtual ICollection<ProjectUsers> ProjectUsers { get; set; }
    }
}