using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MovieReviewWebsite.Models;

namespace MovieReviewWebsite.Controllers
{
    public class ForumController : Controller
    {
        private MovieContext db = new MovieContext();

        // GET: Forum
        public ActionResult Index()
        {

            ViewBag.UserId = User.Identity.Name;//impletemnt
            return View(db.Forums.ToList());
        }
        [HttpGet]
        // GET: Forum/Details/5
        public ActionResult Details(int? id)
        {

            ViewBag.UserId = User.Identity.Name;//impletemnt
            List<Comment> lstComment = db.Comment.Where(c => c.PersonID == id).ToList();
            foreach (Comment item in lstComment)
            {
                CommentReply commentReply = new CommentReply();
                List<CommentReply> lstCommentReply = new List<CommentReply>();
                if (db.CommentReply.Where(c => c.CommentID == item.CommentID).ToList() != null)//
                {
                    lstCommentReply = db.CommentReply.Where(c => c.CommentID == item.CommentID).ToList();
                }
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum forum = db.Forums.Find(id);
            if (forum == null)
            {
                return HttpNotFound();
            }
            return View(forum);
        }
        [HttpGet]
        public ActionResult CommentReply(int? id, int? commentID)
        {
            ViewBag.id = id;
            ViewBag.commentID = commentID;
            List<Comment> lstComment = db.Comment.Where(c => c.PostID == id).ToList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum forum = db.Forums.Find(id);
            forum.Comment = lstComment;
            int numerosoby = forum.PostID;

        
           
            if (forum == null)
            {
                return HttpNotFound();
            }
            return View(forum);
        }
        [HttpPost]
        public ActionResult CommentReply()
        {
            int id = Convert.ToInt32(Request.Params["PostId"]);
            int commentID = Convert.ToInt32(Request.Params["CommentID"]);
            CommentReply commentReply = new CommentReply();
            commentReply.Content = Request.Params["NewReply"];
            commentReply.CommentID = commentID;
            commentReply.CommentReplyID = 2;
            commentReply.AuthorID = User.Identity.Name;
            commentReply.PostID = 1;
            commentReply.PersonID = id;
            commentReply.MovieID = 0;
            db.CommentReply.Add(commentReply);
            db.SaveChanges();
            //-----------------
            List<Comment> lstComment = db.Comment.Where(c => c.PostID == id).ToList();

            Forum forum = db.Forums.Find(id);
            forum.Comment = lstComment;
            int numerosoby = forum.PostID;

          
            if (forum == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Details/" + id);
        }
        [HttpPost]
        public ActionResult Details()
        {

            ViewBag.UserId = User.Identity.Name;//impletemnt
            int id = Convert.ToInt32(Request.Params["PostId"]);
            Comment comment = new Comment();
            comment.Content = Request.Params["NewComment"];
            comment.AuthorID = User.Identity.Name; 
            comment.PostID = 1;
            comment.PersonID = id;
            comment.MovieID = 1;
            db.Comment.Add(comment);
            db.SaveChanges();
            List<Comment> lstComment = db.Comment.Where(c => c.PersonID == id).ToList();
            foreach (Comment item in lstComment)
            {
                CommentReply commentReply = new CommentReply();
                List<CommentReply> lstCommentReply = new List<CommentReply>();
                if (db.CommentReply.Where(c => c.CommentID == item.CommentID).ToList() != null)//
                {
                    lstCommentReply = db.CommentReply.Where(c => c.CommentID == item.CommentID).ToList();
                }
            }
          
            Forum forum = db.Forums.Find(id);
            forum.Comment = lstComment;
            int numerosoby = forum.PostID;


            if (forum == null)
            {
                return HttpNotFound();
            }
            return View(forum);
        }
        // GET: Forum/Create
        public ActionResult Create()
        {

            ViewBag.UserId = User.Identity.Name;//impletemnt
            return View();
        }

        // POST: Forum/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,PersonID,Title,PostTime,Content")] Forum forum)
        {
            if (ModelState.IsValid)
            {

                forum.UserID = User.Identity.Name;
                db.Forums.Add(forum);
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
            Forum forum = db.Forums.Find(id);
            forum.UserID = User.Identity.Name;
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
        public ActionResult Edit([Bind(Include = "PostID,UserID,Title,PostTime,Content,LikeForums")] Forum forum)
        {
            if (ModelState.IsValid)
            {

                forum.UserID = User.Identity.Name;
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
            Forum forum = db.Forums.Find(id);
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
            Forum forum = db.Forums.Find(id);
            db.Forums.Remove(forum);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Movies/Delete/5
        public ActionResult DeleteComment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comment.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("DeleteComment")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCommentConfirmed(int id, int movieID)
        {
            Comment comment = db.Comment.Find(id);
            db.Comment.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Details/" + movieID);
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
