using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MovieReviewWebsite.Models
{
    public class MovieDataInitialiser: DropCreateDatabaseAlways<MovieContext>
    {
        protected override void Seed(MovieContext context)
        {
            Person cat1 = new Person();
            cat1.personID = 1;
            cat1.personName = "Lala";
            cat1.personSurname = "fsafsa";
            cat1.dateOfBirth = new DateTime(2008, 5, 1, 8, 30, 52);
           // cat1.movies = "Game of Thrones";
            cat1.personRole = "Actor";
            context.People.Add(cat1);




            Person cat2 = new Person();
            cat2.personID = 2;
            cat2.personName = "hugo";
            cat2.personSurname = "HO";
            cat2.dateOfBirth = new DateTime(2028, 3, 4, 8, 30, 52);
          //  cat2.movies = "asadsadsadsad";
            cat2.personRole = "Director";
            context.People.Add(cat2);


            Person p1 = new Person();//p1=person1
            p1.personID = 3;
            p1.personName = "Bob";
            p1.personSurname = "Marley";
            p1.dateOfBirth = new DateTime(2008, 5, 1, 8, 30, 52);
          //  p1.movies = "Cars";
            p1.personRole = "Actor";
            context.People.Add(p1);

            Person p2 = new Person();//p2=person2
            p2.personID = 4;
            p2.personName = "Alf";
            p2.personSurname = "HO";
            p2.dateOfBirth = new DateTime(2028, 3, 4, 8, 30, 52);
          //  p2.movies = "Cars";
            p2.personRole = "Director";
            context.People.Add(p2);


           // MovieContext m = new MovieContext();

            //List<Person> PersonDB = new List<Person>();

            //foreach (Person p in context.People)
            //{
            //    PersonDB.Add(p);
            //}


            Movie prod1 = new Movie();
            prod1.MovieID = 1;

            prod1.MovieName = "Cars";
            prod1.Description = "Animated movie";
            prod1.CategoryName = "Horror";
            prod1.Rating = 3.0f;
          
            prod1.People = new List<Person>();

            //foreach (Person p in PersonDB)
            //{
               
            //    if (p.movies == "Cars")
            //    {
            //        prod1.People.Add(p);
            //    }
            //}
            context.Movies.Add(prod1);


            MoviePerson mp = new MoviePerson();
            mp.MoviePersonId = 1;
            mp.MovieID = 1;
            mp.personID = 3;
            context.MoviePerson.Add(mp);


            MoviePerson mp1 = new MoviePerson();
            mp1.MoviePersonId = 2;
            mp1.MovieID = 1;
            mp1.personID = 1;
            context.MoviePerson.Add(mp1);

            MoviePerson mp2 = new MoviePerson();
            mp2.MoviePersonId = 3;
            mp2.MovieID = 2;
            mp2.personID = 4;
            context.MoviePerson.Add(mp2);

            Movie prod2 = new Movie();
            prod2.MovieID = 2;

            prod2.MovieName = "Fast and Furious 261";
            prod2.Description = "More terrible car wrecks";
            prod2.CategoryName = "Horror";
            prod2.Rating = 7.0f;
            context.Movies.Add(prod2);

            base.Seed(context);
        }

    }
}