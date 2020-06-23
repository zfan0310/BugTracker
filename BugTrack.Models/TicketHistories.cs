using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.Models
{
    public class TicketHistories : BaseEntity
    {
        [ForeignKey("Users")]
        public Guid UserId { get; set; }
        public virtual Users Users { get; set; }
        public string Property { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime Changed { get; set; }
        [ForeignKey("Tickets")]
        public Guid TicketId { get; set; }
        public virtual Tickets Tickets { get; set; }

    }
}
