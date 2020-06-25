using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.DTO
{
    public class TicketDto
    {
        public TicketDto()
        {
            this.Tickets = new List<TicketDto>();
        }
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Updated { get; set; }
        public Guid ProjectId { get; set; }
        public Guid ticketTypeId { get; set; }
        public Guid TicketPriorityId { get; set; }
        public Guid TicketStatusId { get; set; }
        public Guid OwnerUserId { get; set; }
        public Guid? AssignedToUserId { get; set; }
        public List<TicketDto> Tickets { get; set; }
    }
}
