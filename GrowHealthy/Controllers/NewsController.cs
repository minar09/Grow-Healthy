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
    public class NewsController : Controller
    {
        private NewsDBContext db = new NewsDBContext();

        //
        // GET: /News/

        public ActionResult Index()
        {
            return View(db.NewsPosts.ToList());
        }

        //
        // GET: /News/Details/5

        public ActionResult Details(int id = 0)
        {
            NewsModels newsmodels = db.NewsPosts.Find(id);
            if (newsmodels == null)
            {
                return HttpNotFound();
            }
            return View(newsmodels);
        }

        //
        // GET: /News/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /News/Create

        [HttpPost]
        public ActionResult Create(NewsModels newsmodels)
        {
            if (ModelState.IsValid)
            {
                db.NewsPosts.Add(newsmodels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsmodels);
        }

        //
        // GET: /News/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NewsModels newsmodels = db.NewsPosts.Find(id);
            if (newsmodels == null)
            {
                return HttpNotFound();
            }
            return View(newsmodels);
        }

        //
        // POST: /News/Edit/5

        [HttpPost]
        public ActionResult Edit(NewsModels newsmodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsmodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsmodels);
        }

        //
        // GET: /News/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NewsModels newsmodels = db.NewsPosts.Find(id);
            if (newsmodels == null)
            {
                return HttpNotFound();
            }
            return View(newsmodels);
        }

        //
        // POST: /News/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsModels newsmodels = db.NewsPosts.Find(id);
            db.NewsPosts.Remove(newsmodels);
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