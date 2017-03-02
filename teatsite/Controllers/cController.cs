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
        [Authorize(Roles = "Admin")]
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
          [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.news_ids = new SelectList(db.tNews, "news_id", "title");
            return View();
        }

        //
        // POST: /c/Create
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tComment tcomment, int? id)
        {
            if (ModelState.IsValid)
            {
                string ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"];
                tcomment.http_posted = ip;
                tcomment.addedcomment = DateTime.Now;
                db.tComment.Add(tcomment);
                db.SaveChanges();
                return RedirectToAction("post", "n", new { id = tcomment.news_ids });
            }

            ViewBag.news_ids = new SelectList(db.tNews, "news_id", "title", tcomment.news_ids==id);
            return View(tcomment);
        }

        //
        // GET: /c/Edit/5
          [Authorize(Roles = "Admin")]
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


           [Authorize(Roles = "Admin")]
        //
        // GET: /c/Delete/5
        [Authorize(Roles="Admin")]
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

        public PartialViewResult commread(int? id)
        {
            var tcomment = db.tComment.Where(t => t.news_ids == id);
            tcomment=tcomment.OrderByDescending(t => t.addedcomment);
            return PartialView("_commread", tcomment.ToList().Take(20));
        }


        public PartialViewResult comm(int id)
        {




            tComment c = new tComment();
            c.news_ids = id;

            //db.tComment.Add(tcomment);
            //db.SaveChanges();
            //}
            return PartialView("_comm", c);
            // return View(quess.ToPagedList(pageNumber, pageSize));
        }

        public PartialViewResult cCnt(int id)
        {
            string tt = db.tComment.Where(i => i.news_ids == id).Count().ToString();
            return PartialView("_test", tt);
        }

        public PartialViewResult GetUserIP()
        {
            string ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"];

            return PartialView("_ip", ip);
        }





        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}