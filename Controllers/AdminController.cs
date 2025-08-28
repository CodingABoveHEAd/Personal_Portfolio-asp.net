using System.Web.Mvc;
using Personal_Portfolio2.Filters;
using Personal_Portfolio2.Models;
using System.Linq;

namespace Personal_Portfolio2.Controllers
{
    [AdminAuthorize]
    public class AdminController : Controller
    {
        private PortfolioContext db = new PortfolioContext();

        public ActionResult Dashboard()
        {
            ViewBag.ProjectCount = db.Projects.Count();
            ViewBag.MessageCount = db.ContactMessages.Count();
            return View();
        }

        // Admin list of projects
        public ActionResult Projects()
        {
            var projects = db.Projects.ToList();
            return View(projects);
        }

        public ActionResult Messages()
        {
            var msgs = db.ContactMessages
                         .OrderByDescending(m => m.Id)
                         .ToList();
            return View(msgs);
        }
    }
}
