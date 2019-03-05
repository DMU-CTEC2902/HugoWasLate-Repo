using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieReviewWebsite.Models;

namespace MovieReviewWebsite.Controllers
{
    public class ForumController : Controller
    {
        private ForumContext db = new ForumContext();

        // GET: Forum
        public ActionResult Index()
        {
           
            return View(db.Fora.ToList());
        }

        // GET: Forum/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum forum = db.Fora.Find(id);
            if (forum == null)
            {
                return HttpNotFound();
            }
            return View(forum);
        }

        // GET: Forum/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Forum/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "postID,postTitle,postContent,postAuthorID,CategoryName")] Forum forum)
        {
            if (ModelState.IsValid)
            {
                db.Fora.Add(forum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(forum);
        }

        // GET: Forum/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum forum = db.Fora.Find(id);
            if (forum == null)
            {
                return HttpNotFound();
            }
            return View(forum);
        }

        // POST: Forum/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "postID,postTitle,postContent,postAuthorID,CategoryName")] Forum forum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(forum);
        }

        // GET: Forum/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum forum = db.Fora.Find(id);
            if (forum == null)
            {
                return HttpNotFound();
            }
            return View(forum);
        }

        // POST: Forum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Forum forum = db.Fora.Find(id);
            db.Fora.Remove(forum);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
