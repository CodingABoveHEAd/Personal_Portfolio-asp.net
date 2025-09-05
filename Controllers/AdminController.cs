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
           //count
            ViewBag.ProjectCount = db.Database.SqlQuery<int>("SELECT COUNT(*) FROM Projects").FirstOrDefault();
            ViewBag.MessageCount = db.Database.SqlQuery<int>("SELECT COUNT(*) FROM ContactMessages").FirstOrDefault();
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
