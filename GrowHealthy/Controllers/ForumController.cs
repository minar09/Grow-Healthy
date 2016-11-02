using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrowHealthy.Models;

namespace GrowHealthy.Controllers
{
    public class ForumController : Controller
    {
        private ForumDBContext db = new ForumDBContext();

        //
        // GET: /Forum/

        public ActionResult Index()
        {
            return View(db.ForumPosts.ToList());
        }

        //
        // GET: /Forum/Details/5

        public ActionResult Details(int id = 0)
        {
            ForumModels forummodels = db.ForumPosts.Find(id);
            if (forummodels == null)
            {
                return HttpNotFound();
            }
            return View(forummodels);
        }

        //
        // GET: /Forum/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Forum/Create

        [HttpPost]
        public ActionResult Create(ForumModels forummodels)
        {
            if (ModelState.IsValid)
            {
                forummodels.PublishDate = DateTime.Now;
                forummodels.Writer = User.Identity.Name;
                db.ForumPosts.Add(forummodels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(forummodels);
        }

        //
        // GET: /Forum/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ForumModels forummodels = db.ForumPosts.Find(id);
            if (forummodels == null)
            {
                return HttpNotFound();
            }
            return View(forummodels);
        }

        //
        // POST: /Forum/Edit/5

        [HttpPost]
        public ActionResult Edit(ForumModels forummodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forummodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(forummodels);
        }

        //
        // GET: /Forum/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ForumModels forummodels = db.ForumPosts.Find(id);
            if (forummodels == null)
            {
                return HttpNotFound();
            }
            return View(forummodels);
        }

        //
        // POST: /Forum/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ForumModels forummodels = db.ForumPosts.Find(id);
            db.ForumPosts.Remove(forummodels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}