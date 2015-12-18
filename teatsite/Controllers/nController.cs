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
    public class nController : Controller
    {
        private att_khovd_drama_dbEntities db = new att_khovd_drama_dbEntities();

        //
        // GET: /n/

        public ActionResult Index()
        {
            var tnews = db.tNews.Include(t => t.tComment).Include(t => t.tMenu).Include(t => t.tSubmenu);
            return View(tnews.ToList());
        }

        //
        // GET: /n/Details/5

        public ActionResult Details(int id = 0)
        {
            tNews tnews = db.tNews.Find(id);
            if (tnews == null)
            {
                return HttpNotFound();
            }
            return View(tnews);
        }

        //
        // GET: /n/Create

        public ActionResult Create()
        {
            ViewBag.news_id = new SelectList(db.tComment, "comment_id", "name");
            ViewBag.menus_ids = new SelectList(db.tMenu, "menu_id", "name");
            ViewBag.subs_id = new SelectList(db.tSubmenu, "sub_id", "name");
            return View();
        }

        //
        // POST: /n/Create
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tNews tnews)
        {
            if (ModelState.IsValid)
            {
                db.tNews.Add(tnews);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.news_id = new SelectList(db.tComment, "comment_id", "name", tnews.news_id);
            ViewBag.menus_ids = new SelectList(db.tMenu, "menu_id", "name", tnews.menus_ids);
            ViewBag.subs_id = new SelectList(db.tSubmenu, "sub_id", "name", tnews.subs_id);
            return View(tnews);
        }

        //
        // GET: /n/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tNews tnews = db.tNews.Find(id);
            if (tnews == null)
            {
                return HttpNotFound();
            }
            ViewBag.news_id = new SelectList(db.tComment, "comment_id", "name", tnews.news_id);
            ViewBag.menus_ids = new SelectList(db.tMenu, "menu_id", "name", tnews.menus_ids);
            ViewBag.subs_id = new SelectList(db.tSubmenu, "sub_id", "name", tnews.subs_id);
            return View(tnews);
        }

        //
        // POST: /n/Edit/5
          [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tNews tnews)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tnews).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.news_id = new SelectList(db.tComment, "comment_id", "name", tnews.news_id);
            ViewBag.menus_ids = new SelectList(db.tMenu, "menu_id", "name", tnews.menus_ids);
            ViewBag.subs_id = new SelectList(db.tSubmenu, "sub_id", "name", tnews.subs_id);
            return View(tnews);
        }

        //
        // GET: /n/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tNews tnews = db.tNews.Find(id);
            if (tnews == null)
            {
                return HttpNotFound();
            }
            return View(tnews);
        }

        //
        // POST: /n/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tNews tnews = db.tNews.Find(id);
            db.tNews.Remove(tnews);
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