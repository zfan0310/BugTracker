using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.DTO
{
    public class TicketCommentsDto
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }
        public Guid TicketId { get; set; }
        public string TicketName { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
    }
}
