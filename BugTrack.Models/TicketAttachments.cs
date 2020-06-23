using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.Models
{
    public class TicketAttachments : BaseEntity
    {
        [ForeignKey("Tickets")]
        public Guid TicketId { get; set; }
        public virtual Tickets Tickets { get; set; }
        public string FilePath { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [ForeignKey("Users")]
        public Guid UserId { get; set; }
        public virtual Users Users { get; set; }
    }
}
