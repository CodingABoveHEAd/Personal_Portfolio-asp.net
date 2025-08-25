using System.Web.Mvc;
using Personal_Portfolio2.Models;

namespace Personal_Portfolio2.Controllers
{
    public class ContactController : Controller
    {
        private PortfolioContext db = new PortfolioContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContactMessage message)
        {
            if (ModelState.IsValid)
            {
                db.ContactMessages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Thanks");
            }
            return View(message);
        }

        public ActionResult Thanks()
        {
            return View();
        }
    }
}
