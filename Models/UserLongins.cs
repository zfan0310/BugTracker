using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADKZ_BugTrack.Models
{
    public class UserLongins
    {
        public Guid Id { get; set; } = new Guid();
        public string LoginProvider { get; set; }

        [StringLength(maximumLength:50,MinimumLength =6)]
        public string ProviderKey { get; set; }
        public Guid UserId { get; set; }
        public virtual Users Users { get; set; }
    }
}