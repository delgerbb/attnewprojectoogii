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
    public class menuController : Controller
    {
        private att_khovd_drama_dbEntities db = new att_khovd_drama_dbEntities();

        //
        // GET: /menu/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.tMenu.ToList());
        }


        public PartialViewResult mList()
        {
            return PartialView("_menu_list",db.tMenu.ToList());
        }
    

        public PartialViewResult menu_list()
        {
            return PartialView("_listmenu",db.tMenu.ToList());
        }


        //
        // GET: /menu/Details/5

        public ActionResult Details(int id = 0)
        {
            tMenu tmenu = db.tMenu.Find(id);
            if (tmenu == null)
            {
                return HttpNotFound();
            }
            return View(tmenu);
        }

        //
        // GET: /menu/Create
         [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /menu/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tMenu tmenu)
        {
            if (ModelState.IsValid)
            {
                tmenu.addeddate = DateTime.Now;
                db.tMenu.Add(tmenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tmenu);
        }

        //
        // GET: /menu/Edit/5
         [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id = 0)
        {
            tMenu tmenu = db.tMenu.Find(id);
            if (tmenu == null)
            {
                return HttpNotFound();
            }
            return View(tmenu);
        }

        //
        // POST: /menu/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tMenu tmenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tmenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tmenu);
        }

        //
        // GET: /menu/Delete/5
         [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id = 0)
        {
            tMenu tmenu = db.tMenu.Find(id);
            if (tmenu == null)
            {
                return HttpNotFound();
            }
            return View(tmenu);
        }

        //
        // POST: /menu/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tMenu tmenu = db.tMenu.Find(id);
            db.tMenu.Remove(tmenu);
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