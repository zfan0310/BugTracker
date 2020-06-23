using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.Models
{
    public class TicketTypes : BaseEntity
    {
        public TicketTypes()
        {
            this.Tickets = new HashSet<Tickets>();
        }

        public string Name { get; set; }
        public ICollection<Tickets> Tickets { get; set; }
    }
}
