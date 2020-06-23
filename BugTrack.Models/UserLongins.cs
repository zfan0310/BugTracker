using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.Models
{
    public class UserLongins : BaseEntity
    {
        public string LoginProvider { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 6)]
        public string ProviderKey { get; set; }
        public Guid UserId { get; set; }
        public virtual Users Users { get; set; }
    }
}
