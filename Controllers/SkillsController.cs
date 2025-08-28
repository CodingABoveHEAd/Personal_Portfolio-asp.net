using System.Linq;
using System.Web.Mvc;
using Personal_Portfolio2.Models;

namespace Personal_Portfolio2.Controllers
{
    public class SkillsController : Controller
    {
        private PortfolioContext db = new PortfolioContext();

        public ActionResult Index()
        {
            var skills = db.Skills.ToList();
            return View(skills);
        }
    }
}
