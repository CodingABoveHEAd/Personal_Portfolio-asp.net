using System.Linq;
using System.Web.Mvc;
using Personal_Portfolio2.Models;

namespace Personal_Portfolio2.Controllers
{
    public class EducationController : Controller
    {
        private PortfolioContext db = new PortfolioContext();

        public ActionResult Index()
        {
            var educations = db.Educations.OrderByDescending(e => e.Id).ToList();
            return View(educations);
        }
    }
}
