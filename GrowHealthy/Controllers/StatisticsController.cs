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
    public class StatisticsController : Controller
    {
        private StatisticsDBContext db = new StatisticsDBContext();

        //
        // GET: /Statistics/

        public ActionResult Index()
        {
            return View(db.StatisticsPosts.ToList());
        }

        //
        // GET: /Statistics/Details/5

        public ActionResult Details(int id = 0)
        {
            StatisticsModels statisticsmodels = db.StatisticsPosts.Find(id);
            if (statisticsmodels == null)
            {
                return HttpNotFound();
            }
            return View(statisticsmodels);
        }

        //
        // GET: /Statistics/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Statistics/Create

        [HttpPost]
        public ActionResult Create(StatisticsModels statisticsmodels)
        {
            if (ModelState.IsValid)
            {
                db.StatisticsPosts.Add(statisticsmodels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statisticsmodels);
        }

        //
        // GET: /Statistics/Edit/5

        public ActionResult Edit(int id = 0)
        {
            StatisticsModels statisticsmodels = db.StatisticsPosts.Find(id);
            if (statisticsmodels == null)
            {
                return HttpNotFound();
            }
            return View(statisticsmodels);
        }

        //
        // POST: /Statistics/Edit/5

        [HttpPost]
        public ActionResult Edit(StatisticsModels statisticsmodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statisticsmodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statisticsmodels);
        }

        //
        // GET: /Statistics/Delete/5

        public ActionResult Delete(int id = 0)
        {
            StatisticsModels statisticsmodels = db.StatisticsPosts.Find(id);
            if (statisticsmodels == null)
            {
                return HttpNotFound();
            }
            return View(statisticsmodels);
        }

        //
        // POST: /Statistics/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            StatisticsModels statisticsmodels = db.StatisticsPosts.Find(id);
            db.StatisticsPosts.Remove(statisticsmodels);
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