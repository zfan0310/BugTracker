using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.Models
{
    public class UserClaims : BaseEntity
    {
        [ForeignKey("Users")]
        public Guid UserId { get; set; }
        public virtual Users Users { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
