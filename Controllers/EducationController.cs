using System.Linq;
using System.Web.Mvc;
using Personal_Portfolio2.Models;
using System.Collections.Generic;

namespace Personal_Portfolio2.Controllers
{
    public class EducationController : Controller
    {
        private PortfolioContext db = new PortfolioContext();
        public ActionResult Index()
        {
            List<Education> educations = db.Database.SqlQuery<Education>(
                "SELECT Id, Degree, Institute, Year FROM Educations ORDER BY Id DESC"
            ).ToList();

            return View(educations);
        }
    }
}
