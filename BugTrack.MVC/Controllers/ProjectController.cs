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
    [TrackAuthattribute]
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateProject()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public async Task< ActionResult> CreateProject(ProjectModel p)
        {
            if (ModelState.IsValid)
            {
                IBLL.IProjectManager projectManager = new ProjectManager();
               await projectManager.CreateProject(p.Name,
                    Guid.Parse(Session["userId"].ToString()));

                return Redirect(Url.Action("Index", "Home"));
            }
            ModelState.AddModelError("", "You are always wrong!");
            return View(p);
        }
    }
}