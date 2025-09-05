using System.Linq;
using System.Web.Mvc;
using Personal_Portfolio2.Models;
using System.Collections.Generic;

namespace Personal_Portfolio2.Controllers
{
    public class SkillsController : Controller
    {
        private PortfolioContext db = new PortfolioContext();

        // READ (using raw SQL instead of LINQ)
        public ActionResult Index()
        {
            List<Skill> skills = db.Database.SqlQuery<Skill>(
                "SELECT Id, Name, Level FROM Skills"
            ).ToList();

            return View(skills);
        }
    }
}
