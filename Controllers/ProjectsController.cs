using System.Linq;
using System.Net;
using System.Web.Mvc;
using Personal_Portfolio2.Filters;
using Personal_Portfolio2.Models;

namespace Personal_Portfolio2.Controllers
{
    public class ProjectsController : Controller
    {
        private PortfolioContext db = new PortfolioContext();

        // Public list (portfolio)
        public ActionResult Index()
        {
            var projects = db.Projects.ToList();
            return View(projects);
        }

        //ADMIN CRUD
        [AdminAuthorize]
        public ActionResult Details(int id)
        {
            var project = db.Projects.Find(id);
            if (project == null) return HttpNotFound();
            return View(project);
        }

        [AdminAuthorize]
        public ActionResult Create()
        {
            return View(new Project());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create(Project model)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(model);
                db.SaveChanges();
                return RedirectToAction("Projects", "Admin");
            }
            return View(model);
        }

        [AdminAuthorize]
        public ActionResult Edit(int id)
        {
            var project = db.Projects.Find(id);
            if (project == null) return HttpNotFound();
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit(Project model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Projects", "Admin");
            }
            return View(model);
        }

        [AdminAuthorize]
        public ActionResult Delete(int id)
        {
            var project = db.Projects.Find(id);
            if (project == null) return HttpNotFound();
            return View(project);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var p = db.Projects.Find(id);
            if (p != null)
            {
                db.Projects.Remove(p);
                db.SaveChanges();
            }
            return RedirectToAction("Projects", "Admin");
        }
    }
}
