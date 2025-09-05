using Personal_Portfolio2.Models;
using System.Web.Mvc;

namespace Personal_Portfolio2.Controllers
{
    public class ContactController : Controller
    {
        private PortfolioContext db = new PortfolioContext();

        // GET
        public ActionResult Index()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContactMessage contact)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand(
                    "INSERT INTO ContactMessages (Name, Email, Message,DateSent) VALUES (@p0, @p1, @p2, @p3)",
                    contact.Name,
                    contact.Email,
                    contact.Message,
                    contact.DateSent
          
                );

                ViewBag.Message = "Your message has been sent successfully!";
                return View();
            }

            return View(contact);
        }
    }
}
