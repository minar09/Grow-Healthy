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
    public class BlogController : Controller
    {
        private BlogDBContext db = new BlogDBContext();

        //
        // GET: /Blog/

        public ActionResult Index()
        {
            return View(db.BlogPosts.ToList());
        }

        //
        // GET: /Blog/Details/5

        public ActionResult Details(int id = 0)
        {
            BlogModels blogmodels = db.BlogPosts.Find(id);
            if (blogmodels == null)
            {
                return HttpNotFound();
            }
            return View(blogmodels);
        }

        //
        // GET: /Blog/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Blog/Create

        [HttpPost]
        public ActionResult Create(BlogModels blogmodels)
        {
            if (ModelState.IsValid)
            {
                blogmodels.PublishDate = DateTime.Now;
                blogmodels.UpdateTime = DateTime.Now;
                blogmodels.Writer = User.Identity.Name;
                db.BlogPosts.Add(blogmodels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogmodels);
        }

        //
        // GET: /Blog/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BlogModels blogmodels = db.BlogPosts.Find(id);
            if (blogmodels == null)
            {
                return HttpNotFound();
            }
            return View(blogmodels);
        }

        //
        // POST: /Blog/Edit/5

        [HttpPost]
        public ActionResult Edit(BlogModels blogmodels)
        {
            if (ModelState.IsValid)
            {
                blogmodels.UpdateTime = DateTime.Now;
                db.Entry(blogmodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogmodels);
        }

        //
        // GET: /Blog/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BlogModels blogmodels = db.BlogPosts.Find(id);
            if (blogmodels == null)
            {
                return HttpNotFound();
            }
            return View(blogmodels);
        }

        //
        // POST: /Blog/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogModels blogmodels = db.BlogPosts.Find(id);
            db.BlogPosts.Remove(blogmodels);
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