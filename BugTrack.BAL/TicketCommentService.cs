
using BugTrack.IDAL;
using BugTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.DAL
{
    public class TicketCommentService:BaseService<TicketComments>,ITicketCommentService
    {
        public TicketCommentService():base(new Context()) { }
    }
}
