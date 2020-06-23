using BugTrack.IDAL;
using BugTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.DAL
{
    public class TicketTypeService: BaseService<TicketTypes>,ITicketTypeService
    {
        public TicketTypeService():base(new Context()) { }
    }
}
