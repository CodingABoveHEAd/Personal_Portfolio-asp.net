using System.Linq;
using System.Web.Mvc;
using Personal_Portfolio2.Models;
using System.Collections.Generic;

namespace Personal_Portfolio2.Controllers
{
    public class HomeController : Controller
    {
        private PortfolioContext db = new PortfolioContext();

        public ActionResult Index()
        {
            return View();
        }
    }
}
