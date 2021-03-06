﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.Models
{
    public class Roles : BaseEntity
    {
        public Roles()
        {
            this.UserRoles = new HashSet<UserRoles>();
        }

        [StringLength(maximumLength: 50, MinimumLength = 6)]
        [Required]
        public string Name { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
