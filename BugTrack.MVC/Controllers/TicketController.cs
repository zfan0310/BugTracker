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
    public class TicketController : Controller
    {
        // GET: Ticket
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        
       [HttpGet]
        public ActionResult CreateTicketPriority()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateTicketPriority(TicketPriorityModel t)
        {
            if (ModelState.IsValid)
            {
                IBLL.ITicketManager ticketManager = new TicketManager();
                await ticketManager.CreateTicketPriority(t.Name);
                return Redirect(Url.Action("Index", "Home"));
            }
            ModelState.AddModelError("", "There are some wrong here");
            return View(t);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateTicketStatus()
        {
            return View();
        }
        [HttpPost]
        public async Task< ActionResult> CreateTicketStatus(TicketStatuModel t)
        {
            if (ModelState.IsValid)
            {
                IBLL.ITicketManager ticketManager = new TicketManager();
                await ticketManager.CreateTicketStatus(t.Name);
                return Redirect(Url.Action("Index", "Home"));
            }
            ModelState.AddModelError("", "There are some wrong here");
            return View(t);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //CreateTicketComment
        [HttpGet]
        public ActionResult CreateTicketType()
        {
            return View();
        }
        [HttpPost]
        [TrackAuthattribute]
        public async Task< ActionResult> CreateTicketType(TicketTypeModel m)
        {
            if (ModelState.IsValid)
            {
                IBLL.ITicketManager ticketManager = new TicketManager();
                await ticketManager.CreateTicketType(m.Name);
                return RedirectToAction("TicketTypeList");
            }
            ModelState.AddModelError("", "There are some wrong here");
            return View(m);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task< ActionResult> TicketTypeList()
        {
            return View(await new TicketManager().GetAllTicketType());
        }

        /*
        [HttpGet]
        public ActionResult CreateProject()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTicket(ProjectModel p)
        {
            if (ModelState.IsValid)
            {
                IBLL.IProjectManager projectManager = new ProjectManager();
                projectManager.CreateProject(p.Name,
                    Guid.Parse(Session["userId"].ToString()));
                return Redirect(Url.Action("Index", "Home"));
            }
            ModelState.AddModelError("", "You are always wrong!");
            return View(p);
        }*/
        [HttpGet]
        [TrackAuthattribute]
        public async Task< ActionResult> GetTicketsByUserId()
        {
            var userId = Guid.Parse(Session["userId"].ToString());
            return View(await new TicketManager().GetAllTicketByUserId(userId));
        }
        /* 
        public async Task<ActionResult> GetAllTicketByType()
        {
            var userId = Guid.Parse(Session["userId"].ToString());
            return View(await new TicketManager().GetAllTicketByUserId(userId));
        }*/
    }
}