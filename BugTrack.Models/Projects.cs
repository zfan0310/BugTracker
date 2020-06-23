using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.Models
{
    public class Projects : BaseEntity
    {
        public Projects()
        {
            this.Tickets = new HashSet<Tickets>();
            this.ProjectUsers = new HashSet<ProjectUsers>();
        }

        [DataType(DataType.Text)]
        public string Name { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }
        public virtual ICollection<ProjectUsers> ProjectUsers { get; set; }
    }
}
