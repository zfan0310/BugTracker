using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.Models
{
    public class TicketStatuses : BaseEntity
    {
        public TicketStatuses()
        {
            this.Tickets = new HashSet<Tickets>();
        }

        public string Name { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
