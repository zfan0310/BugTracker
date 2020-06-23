using BugTrack.IDAL;
using BugTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.DAL
{
    public  class TicketStatusService:BaseService<TicketStatuses>,ITicketStatusService
    {
        public TicketStatusService():base(new Context()) { }
    }
}
