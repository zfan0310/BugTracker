using BLL;
using BugTrack.IBLL;
using BugTrack.MVC.Filter;
using BugTrack.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BugTrack.MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [TrackAuthattribute]
        public ActionResult CreateRole(RoleModel r)
        {
            if (ModelState.IsValid)
            {
                IUserManager userManger = new UserManager();
                userManger.CreateRole(r.Name);
                return Redirect(Url.Action("Index", "Home"));
            }
            ModelState.AddModelError("", "Wrong Wrong Wrong...");
            return View(r);
        }

        [HttpGet]
        public ActionResult CreateUserRoles()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [TrackAuthattribute]
        public ActionResult CreateUserRoles(Guid userId, Guid roleId)
        {
            if (ModelState.IsValid)
            {
                IUserManager userManger = new UserManager();
                userManger.CreateUserRoles(userId,roleId);
                return Redirect(Url.Action("Index", "Home"));
            }
            ModelState.AddModelError("", "Wrong Wrong Wrong...");
            return View();
        }
    }
}