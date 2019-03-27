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
            float averageRating = 0;
            int count = 0;
            foreach (Comment item in lstComment)
            {
                CommentReply commentReply = new CommentReply();
                List<CommentReply> lstCommentReply = new List<CommentReply>();
                if (db.CommentReply.Where(c => c.CommentID == item.CommentID).ToList() != null)//
                {
                    lstCommentReply = db.CommentReply.Where(c => c.CommentID == item.CommentID).ToList();
                }
                averageRating += item.UserRating;
                count++;
            }

            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Movie movie = db.Movies.Find(id);//
            movie.Comment = lstComment;
            int numerFilmu = movie.MovieID;//
            movie.Rating= averageRating / count;
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
            commentReply.Content = Request.Params["NewReply"];
            commentReply.CommentID = commentID;
            //commentReply.CommentReplyID = 2;
            commentReply.AuthorID = User.Identity.GetUserId();
            commentReply.PostID = 0;
            commentReply.PersonID = 0;
            commentReply.MovieID = id;
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
            comment.Content = Request.Params["NewComment"];
            comment.AuthorID = User.Identity.GetUserId();
            comment.PostID = 1;
            comment.MovieID = id;
            comment.PersonID = 1;
            float averageRating = 0;
            int count = 0;
            comment.UserRating = float.Parse(Request.Params["NewUserRating"]);

            if (comment.UserRating <= 10 && comment.UserRating >= 0.0)
            {
                db.Comment.Add(comment);
                db.SaveChanges();
               
            }
         
            
            List<Comment> lstComment = db.Comment.Where(c => c.MovieID == id).ToList();
            foreach (Comment item in lstComment)
            {
                CommentReply commentReply = new CommentReply();
                List<CommentReply> lstCommentReply = new List<CommentReply>();
                if (db.CommentReply.Where(c => c.CommentID == item.CommentID).ToList() != null)//
                {
                    lstCommentReply = db.CommentReply.Where(c => c.CommentID == item.CommentID).ToList();
                }
                averageRating += item.UserRating;
                count++;
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);//

            int numerFilmu = movie.MovieID;//
            movie.Rating = averageRating / count;
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
        public ActionResult Create([Bind(Include = "MovieID,CategoryName,MovieName,Description,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {

                //List<Comment> lstComment = db.Comment.Where(c => c.MovieID == id).ToList();
                //foreach (Comment item in lstComment)
                //{
                //    CommentReply commentReply = new CommentReply();
                //    List<CommentReply> lstCommentReply = new List<CommentReply>();
                //    if (db.CommentReply.Where(c => c.CommentID == item.CommentID).ToList() != null)//
                //    {
                //        lstCommentReply = db.CommentReply.Where(c => c.CommentID == item.CommentID).ToList();
                //    }
                //List<Person> lstPeople = db.People.ToList();
                //    Person people = new Person();
                //foreach(Person  item in lstPeople )
                //{
                //    lstPeople = item.personName;

                //}
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
        public ActionResult Edit([Bind(Include = "MovieID,CategoryName,MovieName,Description,Rating")] Movie movie)
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
            return RedirectToAction("Details/"+ movieID);
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
}//HugoWasLate
