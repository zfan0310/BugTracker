using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.Models
{
    public class TicketComments : BaseEntity
    {
        [Required]
        [DataType(DataType.Text)]
        public string Comment { get; set; }
        [ForeignKey("Tickets")]
        public Guid TicketId { get; set; }
        public virtual Tickets Tickets { get; set; }
        [ForeignKey("Users")]
        public Guid UserId { get; set; }
        public virtual Users Users { get; set; }
    }
}
