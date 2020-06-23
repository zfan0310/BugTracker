using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.DTO
{
    public class TicketAttachmentsDto
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public string  TicketName { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
    }
}
