﻿using System;
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
            
            ViewBag.UserId = User.Identity.Name;//impletemnt
            
            List<Movie> lstMovies = new List<Movie>();
            if (CategoryName == "Any" || CategoryName == null)
            {
                lstMovies = db.Movies.ToList();
                if (Rating == "Worst") { lstMovies = lstMovies.OrderBy(i => i.Rating).ToList(); }
                else if (Rating == "Best") { lstMovies = lstMovies.OrderByDescending(i => i.Rating).ToList(); }
            }
            else
            { lstMovies = db.Movies.Where(i => i.CategoryName == CategoryName).ToList(); }
            if (Rating == "Worst") { lstMovies = lstMovies.OrderBy(i => i.Rating).ToList(); }
            else if (Rating == "Best") { lstMovies = lstMovies.OrderByDescending(i => i.Rating).ToList(); }



            List<Movie> mo = db.Movies.ToList();
            foreach (Movie movies in mo)
            {
               // Movie movie = new Movie();
                int a = movies.MovieID;
                movies.AverageRating = movies.Rating;
                int count = 1;

                //lstCommentReply = db.CommentReply.Where(c => c.CommentID == item.CommentID).ToList();

                List<Comment> lstComment = db.Comment.Where(c => c.MovieID == a).ToList();
                foreach (Comment item in lstComment)
                {
                    CommentReply commentReply = new CommentReply();
                    List<CommentReply> lstCommentReply = new List<CommentReply>();
                    if (db.CommentReply.Where(c => c.CommentID == item.CommentID).ToList() != null)//
                    {
                        lstCommentReply = db.CommentReply.Where(c => c.CommentID == item.CommentID).ToList();
                    }
                    movies.AverageRating += item.UserRating;
                    count++;
                }

                movies.AverageRating= movies.AverageRating / count;
            }
            return View(lstMovies);
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            ViewBag.UserId = User.Identity.Name;//impletemnt
            Movie movie = db.Movies.Find(id);//

            List<Comment> Allcomment = db.Comment.ToList();
            ViewBag.isban = false;
            foreach (Comment test in Allcomment)
            {

                if (test.isBlocked == true && User.Identity.Name == test.AuthorID)
                {
                    ViewBag.isban = true;
                }
            }

            List<Comment> lstComment = db.Comment.Where(c => c.MovieID == id).ToList();
            float averageRating = movie.Rating;
            int count = 1;
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

            movie.Comment = lstComment;
            int numerFilmu = movie.MovieID;//
            movie.Rating = averageRating / count ;
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
            commentReply.AuthorID = User.Identity.Name;
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

            ViewBag.UserId = User.Identity.Name;//impletemnt
            int id = Convert.ToInt32(Request.Params["MovieID"]);
            Movie movie = db.Movies.Find(id);//
            Comment comment = new Comment();
            comment.Content = Request.Params["NewComment"];
            comment.AuthorID = User.Identity.Name;
            comment.PostID = 1;
            comment.MovieID = id;
            comment.PersonID = 1;
            float averageRating = movie.Rating;
            int count = 1;
            float.TryParse(Request.Params["NewUserRating"], out float resulta);
            comment.UserRating = resulta;

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

            ViewBag.UserId = User.Identity.Name;//impletemnt
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
                movie.User = User.Identity.Name;//added this to user
                movie.CategoryName = Request.Params["CategoryName"];
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }
        [HttpGet]
        public ActionResult AddPeopleToMovie(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Movie movie = db.Movies.Find(id);//

            int numerFilmu = movie.MovieID;//
            ViewBag.movie = movie.MovieName;
            List<MoviePerson> mp = db.MoviePerson.Where(i => i.MovieID == numerFilmu).ToList();
            List<Person> lstPpl = db.People.ToList();
            List<Person> ListToDisplay = new List<Person>();
            if (mp != null)
            {
                foreach (MoviePerson mppp in mp)
                {
                    int x = mppp.personID;
                    Person prs = lstPpl.Where(p => p.personID == x).Single();
                    lstPpl.Remove(prs);
                }

            }


            movie.People = lstPpl;

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);

        }
        [HttpPost]
        public ActionResult AddPeopleToMovie()
        {

            int id = Convert.ToInt32(Request.Params["MovieID"]);


            //selecting people id's from database
            List<int> ListOfPeople = db.People.Select(p => p.personID).ToList();

            List<int> ListOfPeopleSendedFromWeb = new List<int>();
            List<Person> EmptyPeople = new List<Person>();

            foreach (int personid in ListOfPeople)
            {

                if (Request.Params[personid.ToString()] != null)
                {
                    int x = Convert.ToInt32(Request.Params[personid.ToString()]);
                    Person prs = new Person();
                    EmptyPeople.Add(db.People.Where(p => p.personID == x).Single());
                    //adding to movie person
                    MoviePerson mope = new MoviePerson();
                    mope.MovieID = id;
                    mope.personID = x;
                    db.MoviePerson.Add(mope);


                    //  ListOfPeopleSendedFromWeb.Add(personid);
                }
                db.SaveChanges();

            }


            Movie movie = db.Movies.Find(id);//

            int numerFilmu = movie.MovieID;//
            ViewBag.movie = movie.MovieName;
            List<MoviePerson> mp = db.MoviePerson.Where(i => i.MovieID == numerFilmu).ToList();
            /// List<Person> lstPpl = db.People.ToList();
            movie.People = EmptyPeople;

            if (movie == null)
            {
                return HttpNotFound();
            }
            //return View(movie);
            return RedirectToAction("Details/" + id);
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
                movie.User = User.Identity.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        // GET: Movies/Edit/5
        public ActionResult BanUser(int? id)
        {
            ViewBag.UserId = User.Identity.Name;
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

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BanUser([Bind(Include = "CommentID,AuthorID,PersonID,MovieID,PostID,Content,UserRating,isBlocked")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comment);
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
}//HugoWasLate
