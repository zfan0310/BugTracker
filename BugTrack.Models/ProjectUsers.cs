using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.Models
{
    public class ProjectUsers : BaseEntity
    {
        [ForeignKey("Projects")]
        public Guid ProjectId { get; set; }
        public Projects Projects { get; set; }
        [ForeignKey("Users")]
        public Guid UserId { get; set; }
        public Users Users { get; set; }
    }
}
