using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.Models
{
    public class Tickets : BaseEntity
    {
        public Tickets()
        {
            this.TicketAttachments = new HashSet<TicketAttachments>();
            this.TicketComments = new HashSet<TicketComments>();
            this.TicketHistories = new HashSet<TicketHistories>();
            this.TicketNotifications = new HashSet<TicketNotifications>();
        }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        public DateTime Updated { get; set; }
        [ForeignKey("Projects")]
        public Guid ProjectId { get; set; }
        public virtual Projects Projects { get; set; }
        [ForeignKey("TicketTypes")]
        public Guid TicketTypeId { get; set; }
        public virtual TicketTypes TicketTypes { get; set; }
        [ForeignKey("TicketPriorities")]
        public Guid TicketPriorityId { get; set; }
        public virtual TicketPriorities TicketPriorities { get; set; }
        [ForeignKey("TicketStatuses")]
        public Guid TicketStatusId { get; set; }
        public virtual TicketStatuses TicketStatuses { get; set; }
        [ForeignKey("OwnerUsers")]
        public Guid OwnerUserId { get; set; }
        public virtual Users OwnerUsers { get; set; }
        [ForeignKey("AssignedToUser")]
        public Guid AssignedToUserId { get; set; }
        public virtual Users AssignedToUser { get; set; }
        public virtual ICollection<TicketNotifications> TicketNotifications { get; set; }
        public virtual ICollection<TicketHistories> TicketHistories { get; set; }
        public virtual ICollection<TicketComments> TicketComments { get; set; }
        public virtual ICollection<TicketAttachments> TicketAttachments { get; set; }
    }
}
