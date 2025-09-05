using Personal_Portfolio2.Filters;
using Personal_Portfolio2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

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

        public ActionResult Projects()
        {
            List<Project> projects = db.Database.SqlQuery<Project>(
                "SELECT Id, Title, Description, Url, Tags FROM Projects"
            ).ToList();

            return View(projects);
        }

        public ActionResult Messages()
        {
            List<ContactMessage> msgs = db.Database.SqlQuery<ContactMessage>(
                "SELECT Id, Name, Email, Message,DateSent FROM ContactMessages ORDER BY Id DESC"
            ).ToList();

            return View(msgs);
        }
    }
}
