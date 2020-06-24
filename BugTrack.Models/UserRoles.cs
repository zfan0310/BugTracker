using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.Models
{
    public class UserRoles: BaseEntity
    {
        [ForeignKey("Users")]
        public Guid UserId { get; set; }
        public Users Users { get; set; }
        [ForeignKey("Roles")]
        public Guid RolesId { get; set; }
        public Roles Roles { get; set; }
    }
}
