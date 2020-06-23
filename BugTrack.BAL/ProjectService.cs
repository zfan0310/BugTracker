using BugTrack.IDAL;
using BugTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.DAL
{
    public class ProjectService:BaseService<Projects>,IProjectService
    {
        public ProjectService():base(new Context()) { }
    }
}
