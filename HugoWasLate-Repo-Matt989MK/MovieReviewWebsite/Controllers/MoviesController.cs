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
    public class MoviesController : Controller
    {
        private MovieContext db = new MovieContext();

        // GET: Movies
        public ActionResult Index(string CategoryName, string Rating)
        {
            ViewBag.UserId = User.Identity.GetUserId();//impletemnt
            List<Movie> lstMovies = new List<Movie>();
            if (CategoryName == "Any" || CategoryName == null)
            {
                lstMovies = db.Movies.ToList();
                if (Rating == "Worst") { lstMovies= lstMovies.OrderBy(i => i.Rating).ToList(); }
              else if (Rating == "Best") { lstMovies=lstMovies.OrderByDescending(i => i.Rating).ToList(); }
            }
            else
            { lstMovies = db.Movies.Where(i => i.CategoryName == CategoryName).ToList(); }
            if (Rating == "Worst") { lstMovies=lstMovies.OrderBy(i => i.Rating).ToList(); }
            else if(Rating == "Best") { lstMovies=lstMovies.OrderByDescending(i => i.Rating).ToList(); }
            return View(lstMovies);
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            List<Comment> lstComment = db.Comment.Where(c => c.MovieID == id).ToList();
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

            Movie movie = db.Movies.Find(id);//
            movie.Comment = lstComment;
            int numerFilmu = movie.MovieID;//

            List<MoviePerson> mp = db.MoviePerson.Where(i => i.MovieID == numerFilmu).ToList();

            foreach (MoviePerson movpers in mp)
            {
                Person p2 = db.People.Find(movpers.personID);
                movie.People.Add(p2);
            }

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        [HttpGet]
        public ActionResult CommentReply(int? id, int? commentID)
        {
            ViewBag.id = id;
            ViewBag.commentID = commentID;
            List<Comment> lstComment = db.Comment.Where(c => c.MovieID == id).ToList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            movie.Comment = lstComment;
            int numerosoby = movie.MovieID;

           
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        [HttpPost]
        public ActionResult CommentReply()
        {
            int id = Convert.ToInt32(Request.Params["MovieID"]);
            int commentID = Convert.ToInt32(Request.Params["CommentID"]);
            CommentReply commentReply = new CommentReply();
            commentReply.Content = Request.Params["Comment"];
            commentReply.CommentID = commentID;
            commentReply.CommentReplyID = 2;
            commentReply.AuthorID = 1;
            commentReply.PostID = 1;
            commentReply.PersonID = id;
            commentReply.MovieID = 1;
            db.CommentReply.Add(commentReply);
            db.SaveChanges();
            //-----------------
            List<Comment> lstComment = db.Comment.Where(c => c.PersonID == id).ToList();

            Movie movie = db.Movies.Find(id);
            movie.Comment = lstComment;
            int numerosoby = movie.MovieID;

            List<MoviePerson> mp = db.MoviePerson.Where(i => i.personID == numerosoby).ToList();
        
            if (movie == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Details/" + id);
        }
        [HttpPost]
        public ActionResult Details()
        {

            int id = Convert.ToInt32(Request.Params["MovieID"]);
            Comment comment = new Comment();
            comment.Content = Request.Params["Comment"];
            comment.AuthorID = 1;
            comment.PostID = 1;
            comment.MovieID = id;
            comment.PersonID = 1;
            db.Comment.Add(comment);
            db.SaveChanges();
            List<Comment> lstComment = db.Comment.Where(c => c.MovieID == id).ToList();
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
            Movie movie = db.Movies.Find(id);//

            int numerFilmu = movie.MovieID;//
          
            List<MoviePerson> mp = db.MoviePerson.Where(i => i.MovieID == numerFilmu).ToList();
          
            foreach (MoviePerson movpers in mp)
            {
                Person p2 = db.People.Find(movpers.personID);
            movie.People.Add(p2);
            }
            
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieID,CategoryName,MovieName,Description,Price,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.User = User.Identity.GetUserId();//added this to user
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

                     return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieID,CategoryName,MovieName,Description,Price,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
