using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ADKZ_BugTrack.Models
{
    public class ProjectUsers
    {
        public Guid Id { get; set; }
        [ForeignKey("Projects")]
        public Guid ProjectId { get; set; }
        public Projects Projects { get; set; }
        [ForeignKey("Users")]
        public Guid UserId { get; set; }
        public Users Users { get; set; }
    }
}