using System.Linq;
using System.Net;
using System.Web.Mvc;
using Personal_Portfolio2.Filters;
using Personal_Portfolio2.Models;
using System.Collections.Generic;

namespace Personal_Portfolio2.Controllers
{
    public class ProjectsController : Controller
    {
        private PortfolioContext db = new PortfolioContext();

        // READ ALL
        public ActionResult Index()
        {
            List<Project> projects = db.Database.SqlQuery<Project>(
                "SELECT Id, Title, Description, Url, Tags FROM Projects"
            ).ToList();

            return View(projects);
        }

        // READ ONE (Details)
        [AdminAuthorize]
        public ActionResult Details(int id)
        {
            var project = db.Database.SqlQuery<Project>(
                "SELECT Id, Title, Description, Url, Tags FROM Projects WHERE Id = @p0", id
            ).FirstOrDefault();

            if (project == null) return HttpNotFound();
            return View(project);
        }

        // CREATE (GET)
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View(new Project());
        }

        // CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create(Project model)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand(
                    "INSERT INTO Projects (Title, Description, Url, Tags) VALUES (@p0, @p1, @p2, @p3)",
                    model.Title, model.Description, model.Url, model.Tags
                );
                return RedirectToAction("Projects", "Admin");
            }
            return View(model);
        }

        // EDIT (GET)
        [AdminAuthorize]
        public ActionResult Edit(int id)
        {
            var project = db.Database.SqlQuery<Project>(
                "SELECT Id, Title, Description, Url, Tags FROM Projects WHERE Id = @p0", id
            ).FirstOrDefault();

            if (project == null) return HttpNotFound();
            return View(project);
        }

        // EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit(Project model)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand(
                    "UPDATE Projects SET Title = @p0, Description = @p1, Url = @p2, Tags = @p3 WHERE Id = @p4",
                    model.Title, model.Description, model.Url, model.Tags, model.Id
                );
                return RedirectToAction("Projects", "Admin");
            }
            return View(model);
        }

        // DELETE (GET)
        [AdminAuthorize]
        public ActionResult Delete(int id)
        {
            var project = db.Database.SqlQuery<Project>(
                "SELECT Id, Title, Description, Url, Tags FROM Projects WHERE Id = @p0", id).FirstOrDefault();

            if (project == null) return HttpNotFound();
            return View(project);
        }

        // DELETE (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Database.ExecuteSqlCommand(
                "DELETE FROM Projects WHERE Id = @p0", id
            );
            return RedirectToAction("Projects", "Admin");
        }
    }
}
