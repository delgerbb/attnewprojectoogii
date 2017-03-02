using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using teatsite.Models;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Configuration;
using ImageResizer;
using PagedList;
using PagedList.Mvc;



namespace teatsite.Controllers
{
    public class nController : Controller
    {
        private att_khovd_drama_dbEntities db = new att_khovd_drama_dbEntities();

        //
        // GET: /n/

        public ActionResult Index(int? page,string Searching)
        {
            var tnews = db.tNews.Include(t => t.tComment).Include(t => t.tMenu).Include(t => t.tSubmenu);
            tnews =tnews.OrderByDescending(t=>t.addedtime);
            if (!String.IsNullOrEmpty(Searching))
            {
                tnews = tnews.Where(s => s.title.Contains(Searching));
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(tnews.ToList().ToPagedList(pageNumber,pageSize));
        }

        public ActionResult s(int? page, string Searching)
        {
            var tnews = db.tNews.Include(t => t.tComment).Include(t => t.tMenu).Include(t => t.tSubmenu);
            tnews = tnews.OrderByDescending(t => t.addedtime);
            if (!String.IsNullOrEmpty(Searching))
            {
                tnews = tnews.Where(s => s.title.Contains(Searching));
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(tnews.ToList().ToPagedList(pageNumber, pageSize));
        }


        public ActionResult c(int? page, int? id)
        {

            var tnews = db.tNews.Where(t => t.subs_id == id);
            tnews = tnews.OrderByDescending(s => s.addedtime);
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(tnews.ToList().ToPagedList(pageNumber, pageSize));
            //return View(tnews.ToList());
        }
        public ActionResult m(int? page, int? id)
        {

            var tnews = db.tNews.Where(t => t.menus_ids == id);
            tnews = tnews.OrderByDescending(s => s.addedtime);
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(tnews.ToList().ToPagedList(pageNumber, pageSize));
            //return View(tnews.ToList());
        }



        public PartialViewResult slider()
        {
            var tnews = db.tNews.Include(t => t.tComment).Include(t => t.tMenu).Include(t => t.tSubmenu);
            tnews = tnews.OrderByDescending(t => t.addedtime);
            return PartialView("_slider",tnews.ToList().Take(3));
        }


        public PartialViewResult lastnews()
        {
            var tnews = db.tNews.Include(t => t.tComment).Include(t => t.tMenu).Include(t => t.tSubmenu);
            tnews = tnews.OrderByDescending(t => t.addedtime);
            return PartialView("_lastnews", tnews.ToList().Take(6));
        }

        public PartialViewResult counter(int id)
        {
           string menucount = db.tNews.Where(t => t.menus_ids == id).Count().ToString();
            return PartialView("_count", menucount);
        }

        public PartialViewResult totalwatch(int id)
        {
            string total = db.tNews.Sum(t=>t.news_count).ToString();
            return PartialView("_tolal", total);
        }

        public PartialViewResult newscount()
        {
            var tnews = db.tNews.Include(t => t.tComment).Include(t => t.tMenu).Include(t => t.tSubmenu);
            //tnews = tnews.OrderByDescending(t => t.addedtime);
            tnews = tnews.OrderByDescending(t => t.news_count);
            return PartialView("_readcount", tnews.ToList().Take(6));
        }

        //
        // GET: /n/Details/5

        public ActionResult post(int id=0)
        {
            tNews tnews = db.tNews.Find(id);

            int cnt = Convert.ToInt32(tnews.news_count);
            //int cnt = tnews.news_count;

            cnt++;
            tnews.news_count = cnt;

            db.Entry(tnews).State = EntityState.Modified;
            db.SaveChanges();
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
            ViewBag.menus_ids = new SelectList(db.tMenu, "menu_id", "name");
            ViewBag.subs_id = new SelectList(db.tSubmenu, "sub_id", "name");
            return View();
        }

        //
        // POST: /n/Create
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(tNews tnews, HttpPostedFileBase file)
        {

            if (file != null)
            {
                //Declare a new dictionary to store the parameters for the image versions.
                var versions = new Dictionary<string, string>();

                var path = Server.MapPath("~/news-images/");

                //Define the versions to generate
                versions.Add("_small", "maxwidth=600&maxheight=600&format=jpg");
                versions.Add("_medium", "maxwidth=470&maxheight=940&format=jpg");
                //versions.Add("_large", "maxwidth=1200&maxheight=1200&format=jpg");

                //Generate each version
                foreach (var suffix in versions.Keys)
                {
                    file.InputStream.Seek(0, SeekOrigin.Begin);

                    //Let the image builder add the correct extension based on the output file type
                    ImageBuilder.Current.Build(
                        new ImageJob(
                            file.InputStream,
                            path + file.FileName+suffix,
                            new Instructions(versions[suffix]),
                            false,
                            true));
                    
                }
            }

            if (ModelState.IsValid)
            {
                tnews.images = file.FileName;
                tnews.addedtime = DateTime.Now;
                db.tNews.Add(tnews);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.menus_ids = new SelectList(db.tMenu, "menu_id", "name");
            ViewBag.subs_id = new SelectList(db.tSubmenu, "sub_id", "name");
            return View(tnews);
        }

        public JsonResult getmenus(int id)
        {
            var query = from tsubmenu in db.tSubmenu
                        select new
                        {
                            id = tsubmenu.sub_id,
                            name = tsubmenu.name,
                            menus_id = tsubmenu.menus_id,

                        };
            query = query.Where(i => i.menus_id == id);
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {

                    Data = query.ToList(),
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                return new JsonResult
                {
                    Data = "ALDAA",
                    JsonRequestBehavior = JsonRequestBehavior.DenyGet
                };
            }
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
        [Authorize(Roles="Admin")]
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
        [Authorize(Roles = "Admin")]
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