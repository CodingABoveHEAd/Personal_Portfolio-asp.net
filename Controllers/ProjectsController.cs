using System.Linq;
using System.Web.Mvc;
using Personal_Portfolio2.Models;

namespace Personal_Portfolio2.Controllers
{
    public class ProjectsController : Controller
    {
        private PortfolioContext db = new PortfolioContext();

        public ActionResult Index()
        {
            var projects = db.Projects.ToList();
            return View(projects);
        }
    }
}
