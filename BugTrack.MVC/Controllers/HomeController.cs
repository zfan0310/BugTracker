using BLL;
using BugTrack.IBLL;
using BugTrack.MVC.Filter;
using BugTrack.MVC.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BugTrack.MVC.Controllers
{
    public class HomeController : Controller
    {
        [TrackAuthattribute]
        public async Task< ActionResult> Index()
        {
            IProjectManager projectManager = new ProjectManager();
            var x=await projectManager.GetAllProjectByUserId(Guid.Parse(Session["userId"].ToString()));
            return View(x);
        }

        [TrackAuthattribute]
        public async Task<ActionResult> ManagerPage()
        {
            IProjectManager projectManager = new ProjectManager();
            var x = await projectManager.GetAllProjectByUserId(Guid.Parse(Session["userId"].ToString()));
            return View(x);
        }

        [TrackAuthattribute]
        public async Task<ActionResult> SubmitterPage()
        {
            Context db = new Context();
            

            IProjectManager projectManager = new ProjectManager();
            var x = await projectManager.GetAllProjectByUserId(Guid.Parse(Session["userId"].ToString()));

            return View(x);
        }
        [TrackAuthattribute]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        [HttpGet]
        [TrackAuthattribute]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(Models.UserModel m)
        {
            if (ModelState.IsValid)
            {
                IBLL.IUserManager userManager = new UserManager();
                await userManager.Register(m.Email, m.Password,m.UserName);
                //Should return a Id to Session
                return Content("Please Wait For Your Admin Give You Role");
            }
            
            return View(m);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        } 
        [HttpPost]
        [ValidateAntiForgeryToken]
        [TrackAuthattribute]
        public async Task< ActionResult> Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                IBLL.IUserManager userManager = new UserManager();
                Guid userId;
                if ( userManager.Login(login.Email, login.Password,login.UserName,out userId))
                {
                    if (login.RememberMe)
                    {
                        Response.Cookies.Add(new HttpCookie("loginName")
                        {
                            Value = login.Email,
                            Expires = DateTime.Now.AddDays(7),
                        });
                        Response.Cookies.Add(new HttpCookie("userId")
                        {
                            Value = userId.ToString(),
                            Expires = DateTime.Now.AddDays(7),
                        });
                        Response.Cookies.Add(new HttpCookie("userName")
                        {
                            Value = login.UserName,
                            Expires = DateTime.Now.AddDays(7),
                        });
                    }
                    else
                    {
                        Session["loginName"] = login.Email;
                        Session["userId"] = userId;
                        Session["userName"] = login.UserName;
                    }
                    
                    /////////////////
                    string userRoleName =await userManager.GetUserRole(userId);
                    if (userRoleName == "Admin")
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else if (userRoleName == "Manager")
                    {
                        return Redirect(Url.Action("ManagerPage", "Home"));
                    }
                    else if (userRoleName == "Developer")
                    {
                        return Content("Developer");
                    }
                    else if (userRoleName == "Submitter")
                    {
                        return Redirect("SubmitterPage");
                    }
                    else
                    {
                        return Content("You Didn't Have Any Role");
                    }
                }
                else
                {
                    ModelState.AddModelError("","Wrong Wrong Wrong...");
                }
            }
            return View(login);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task< ActionResult> CreateUserRole()
        {
            IUserManager userManager = new UserManager();
            ViewBag.RoleId = new SelectList(await userManager.GetAllRoles(), "RoleId", "Name");
            ViewBag.UserId = new SelectList(await userManager.GetAllUsers(), "UserId", "UserName");
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [TrackAuthattribute]
        public async Task<ActionResult> CreateUserRole(Guid UserId, Guid RoleId)
        {
            IUserManager userManager = new UserManager();
            
            await userManager.CreateUserRoles(UserId, RoleId);
            ModelState.AddModelError("", "You are always wrong!");
            return Redirect(Url.Action("Index", "Home"));
        }


    }
}