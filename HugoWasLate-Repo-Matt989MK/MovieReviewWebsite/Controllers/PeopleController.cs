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
    public class PeopleController : Controller
    {
        private MovieContext db = new MovieContext();

        // GET: People
        public ActionResult Index()
        {
            ViewBag.UserId = User.Identity.GetUserId();
            return View(db.People.ToList());
        }

        // GET: People/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {

            ViewBag.UserId = User.Identity.GetUserId();//impletemnt
            List<Comment> lstComment = db.Comment.Where(c => c.PersonID == id).ToList();
                foreach(Comment item in lstComment)
                {
                CommentReply commentReply = new CommentReply();
                List<CommentReply> lstCommentReply = new List<CommentReply>();
                if (db.CommentReply.Where(c => c.CommentID == item.CommentID).ToList() != null)//
                {
                    lstCommentReply =db.CommentReply.Where(c => c.CommentID == item.CommentID).ToList();
                }
                }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            person.Comment = lstComment;
            int numerosoby = person.personID;
            List<MoviePerson> mp = db.MoviePerson.Where(i => i.personID == numerosoby).ToList();
            foreach (MoviePerson movpers in mp)
            {
                Movie m2 = db.Movies.Find(movpers.MovieID);
                person.Movies.Add(m2);
            }
            if (person == null)
            {
                return HttpNotFound();
            }
            
            return View(person);
        }

        [HttpGet]
        public ActionResult CommentReply(int? id,int? commentID)
        {
            ViewBag.id = id;
            ViewBag.commentID = commentID;
            List<Comment> lstComment = db.Comment.Where(c => c.PersonID == id).ToList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            person.Comment = lstComment;
            int numerosoby = person.personID;

            List<MoviePerson> mp = db.MoviePerson.Where(i => i.personID == numerosoby).ToList();
            foreach (MoviePerson movpers in mp)
            {
                Movie m2 = db.Movies.Find(movpers.MovieID);
                person.Movies.Add(m2);
            }
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }
        [HttpPost]
        public ActionResult CommentReply()
        {
            int id = Convert.ToInt32(Request.Params["PersonId"]);
            int commentID = Convert.ToInt32(Request.Params["CommentID"]);
            CommentReply commentReply = new CommentReply();
            commentReply.Content = Request.Params["Comment"];
            commentReply.CommentID = commentID;
            commentReply.CommentReplyID = 2;
            commentReply.AuthorID = User.Identity.GetUserId(); ;
            commentReply.PostID = 1;
            commentReply.PersonID = id;
            commentReply.MovieID = 1;
            db.CommentReply.Add(commentReply);
            db.SaveChanges();
            //-----------------
            List<Comment> lstComment = db.Comment.Where(c => c.PersonID == id).ToList();

            Person person = db.People.Find(id);
            person.Comment = lstComment;
            int numerosoby = person.personID;

            List<MoviePerson> mp = db.MoviePerson.Where(i => i.personID == numerosoby).ToList();
            foreach (MoviePerson movpers in mp)
            {
                Movie m2 = db.Movies.Find(movpers.MovieID);
                person.Movies.Add(m2);
            }
            if (person == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Details/" + id);
        }
        [HttpPost]
        public ActionResult Details()
        {

            ViewBag.UserId = User.Identity.GetUserId();//impletemnt
            int id = Convert.ToInt32(Request.Params["PersonId"]);
            Comment comment = new Comment();
            comment.Content = Request.Params["Comment"];
            comment.AuthorID = User.Identity.GetUserId();
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
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            person.Comment = lstComment;
            int numerosoby = person.personID;

            List<MoviePerson> mp = db.MoviePerson.Where(i => i.personID == numerosoby).ToList();
            foreach (MoviePerson movpers in mp)
            {
                Movie m2 = db.Movies.Find(movpers.MovieID);
                person.Movies.Add(m2);
            }
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }



        // GET: People/Create
        public ActionResult Create()
        {

            ViewBag.UserId = User.Identity.GetUserId();//impletemnt
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "personID,personName,personSurname,dateOfBirth,movies,personRole")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "personID,personName,personSurname,dateOfBirth,movies,personRole")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
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
        public ActionResult DeleteCommentConfirmed(int id, int personID)
        {

            Comment comment = db.Comment.Find(id);
            db.Comment.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Details/" + personID);
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
