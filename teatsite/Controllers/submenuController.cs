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
    public class submenuController : Controller
    {
        private att_khovd_drama_dbEntities db = new att_khovd_drama_dbEntities();

        //
        // GET: /submenu/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var tsubmenu = db.tSubmenu.Include(t => t.tMenu);
            return View(tsubmenu.ToList());
        }


        public PartialViewResult sublist(int? id)
        {
            var tsubmenu = db.tSubmenu.Where(t => t.menus_id==id);
            tsubmenu=tsubmenu.OrderByDescending(s => s.addedtime);
            return PartialView("_submenulist",tsubmenu.ToList());
        }
        //

        //
        // GET: /submenu/Create
           [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.menus_id = new SelectList(db.tMenu, "menu_id", "name");
            return View();
        }

        //
        // POST: /submenu/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult Create(tSubmenu tsubmenu)
        {
            if (ModelState.IsValid)
            {
                tsubmenu.addedtime = DateTime.Now;
                db.tSubmenu.Add(tsubmenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.menus_id = new SelectList(db.tMenu, "menu_id", "name", tsubmenu.menus_id);
            return View(tsubmenu);
        }

        //
        // GET: /submenu/Edit/5
           [Authorize(Roles="Admin")]
        public ActionResult Edit(int id = 0)
        {
            tSubmenu tsubmenu = db.tSubmenu.Find(id);
            if (tsubmenu == null)
            {
                return HttpNotFound();
            }
            ViewBag.menus_id = new SelectList(db.tMenu, "menu_id", "name", tsubmenu.menus_id);
            return View(tsubmenu);
        }

        //
        // POST: /submenu/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult Edit(tSubmenu tsubmenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tsubmenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.menus_id = new SelectList(db.tMenu, "menu_id", "name", tsubmenu.menus_id);
            return View(tsubmenu);
        }

        //
        // GET: /submenu/Delete/5
           [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id = 0)
        {
            tSubmenu tsubmenu = db.tSubmenu.Find(id);
            if (tsubmenu == null)
            {
                return HttpNotFound();
            }
            return View(tsubmenu);
        }

        //
        // POST: /submenu/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tSubmenu tsubmenu = db.tSubmenu.Find(id);
            db.tSubmenu.Remove(tsubmenu);
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