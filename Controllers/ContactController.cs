using Personal_Portfolio2.Models;
using System.Web.Mvc;

namespace Personal_Portfolio2.Controllers
{
    public class ContactController : Controller
    {
        private PortfolioContext db = new PortfolioContext();

        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        // POST: Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContactMessage contact)
        {
            if (ModelState.IsValid)
            {
                db.ContactMessages.Add(contact);  // save to DB
                db.SaveChanges();
                ViewBag.Message = "Your message has been sent successfully!";
                return View();
            }
            return View(contact);
        }
    }
}
