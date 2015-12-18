using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using teatsite.Models;

namespace teatsite.Controllers
{
    public class cController : Controller
    {
        private att_khovd_drama_dbEntities db = new att_khovd_drama_dbEntities();

        //
        // GET: /c/

        public ActionResult Index()
        {
            var tcomment = db.tComment.Include(t => t.tNews);
            return View(tcomment.ToList());
        }

        //
        // GET: /c/Details/5

        public ActionResult Details(int id = 0)
        {
            tComment tcomment = db.tComment.Find(id);
            if (tcomment == null)
            {
                return HttpNotFound();
            }
            return View(tcomment);
        }

        //
        // GET: /c/Create

        public ActionResult Create()
        {
            ViewBag.news_ids = new SelectList(db.tNews, "news_id", "title");
            return View();
        }

        //
        // POST: /c/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tComment tcomment)
        {
            if (ModelState.IsValid)
            {
                db.tComment.Add(tcomment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.news_ids = new SelectList(db.tNews, "news_id", "title", tcomment.news_ids);
            return View(tcomment);
        }

        //
        // GET: /c/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tComment tcomment = db.tComment.Find(id);
            if (tcomment == null)
            {
                return HttpNotFound();
            }
            ViewBag.news_ids = new SelectList(db.tNews, "news_id", "title", tcomment.news_ids);
            return View(tcomment);
        }

        //
        // POST: /c/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tComment tcomment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tcomment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.news_ids = new SelectList(db.tNews, "news_id", "title", tcomment.news_ids);
            return View(tcomment);
        }

        //
        // GET: /c/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tComment tcomment = db.tComment.Find(id);
            if (tcomment == null)
            {
                return HttpNotFound();
            }
            return View(tcomment);
        }

        //
        // POST: /c/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tComment tcomment = db.tComment.Find(id);
            db.tComment.Remove(tcomment);
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