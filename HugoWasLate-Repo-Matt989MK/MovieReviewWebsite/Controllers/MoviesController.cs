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
    public class MoviesController : Controller
    {
        private MovieContext db = new MovieContext();

        // GET: Movies
        public ActionResult Index(string CategoryName, string Rating)
        {
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
