using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.DTO
{
    public class ProjectDto
    {
        public ProjectDto()
        {
            this.tickets = new List<TicketDto>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
