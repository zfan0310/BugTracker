using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADKZ_BugTrack.Models
{
    public class Roles
    {
        public Roles()
        {
            this.Users = new HashSet<Users>();
        }
        [Key]
        public Guid Id { get; set; } = new Guid();
        [StringLength(maximumLength: 50, MinimumLength = 6)]
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}