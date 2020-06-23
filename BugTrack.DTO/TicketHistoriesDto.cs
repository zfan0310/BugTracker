using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.DTO
{
    public class TicketHistoriesDto
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public string Property { get; set; }
        public string OldValue { get; set; }
        public string NweValue { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public bool Changed { get; set; }
    }
}
