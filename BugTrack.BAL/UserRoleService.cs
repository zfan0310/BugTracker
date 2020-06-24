using BugTrack.DAL;
using BugTrack.IDAL;
using BugTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.BAL
{
    public class UserRoleService:BaseService<UserRoles>,IUserRoleService
    {
        public UserRoleService():base(new Context()) { }
    }
}
