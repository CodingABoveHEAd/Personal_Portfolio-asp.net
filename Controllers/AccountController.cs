using System.Web.Mvc;
using Personal_Portfolio2.Helpers;

namespace Personal_Portfolio2.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password, string returnUrl)
        {
            if (SimpleAuth.Validate(username, password))
            {
                Session["IsAdmin"] = true;
                return Redirect(string.IsNullOrEmpty(returnUrl) ? Url.Action("Dashboard", "Admin") : returnUrl);
            }

            ViewBag.Error = "Invalid username or password.";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}
