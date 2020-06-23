using BLL;
using BugTrack.MVC.Filter;
using BugTrack.MVC.Models;
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
        public ActionResult Index()
        {
            return View();
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
                return RedirectToAction(nameof(Index));
            }
            
            return View(m);
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        } 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Login(LoginModel login)
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
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("","Wrong Wrong Wrong...");
                }

            }
            
            return View(login);
        }
    }
}