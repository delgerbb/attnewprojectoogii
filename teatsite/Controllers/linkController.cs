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
    public class linkController : Controller
    {
        private att_khovd_drama_dbEntities db = new att_khovd_drama_dbEntities();

        //
        // GET: /link/

        public ActionResult Index()
        {
            return View(db.tLinks.ToList());
        }

        public PartialViewResult links()
        {
            var tt = db.tLinks.OrderByDescending(s=>s.addedlink);
            return PartialView("_links",tt.ToList().Take(7));
        }



        //
        // GET: /link/Details/5

        public ActionResult Details(int id = 0)
        {
            tLinks tlinks = db.tLinks.Find(id);
            if (tlinks == null)
            {
                return HttpNotFound();
            }
            return View(tlinks);
        }

        //
        // GET: /link/Create
        [ValidateInput(false)]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /link/Create
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tLink tlinks)
        {
            if (ModelState.IsValid)
            {
                tlinks.addedlink = DateTime.Now;
                db.tLinks.Add(tlinks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tlinks);
        }

        //
        // GET: /link/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tLinks tlinks = db.tLinks.Find(id);
            if (tlinks == null)
            {
                return HttpNotFound();
            }
            return View(tlinks);
        }

        //
        // POST: /link/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tLink tlinks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tlinks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tlinks);
        }

        //
        // GET: /link/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tLinks tlinks = db.tLinks.Find(id);
            if (tlinks == null)
            {
                return HttpNotFound();
            }
            return View(tlinks);
        }

        //
        // POST: /link/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tLinks tlinks = db.tLinks.Find(id);
            db.tLinks.Remove(tlinks);
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