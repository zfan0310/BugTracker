using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrack.MVC.Models
{
    public class UserRoleModel
    {
        public Guid userId { get; set; }
        public Guid roleUd { get; set; }
    }
}