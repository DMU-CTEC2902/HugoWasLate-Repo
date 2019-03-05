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


            Movie prod1 = new Movie();
            prod1.MovieID = 1;

            prod1.MovieName = "Cars";
            prod1.Description = "Animated movie";
            prod1.CategoryName = "Horror";
            prod1.Rating = 3.0f;
            prod1.personID = 1;
            prod1.People = new List<Person>();
            Person cat1 = new Person();
            cat1.personID = 1;
            cat1.personName = "Bob";
            cat1.personSurname = "Marley";
            cat1.dateOfBirth = new DateTime(2008, 5, 1, 8, 30, 52);
            cat1.personMovies = "Cars";
            cat1.personRole = "Actor";
            prod1.People.Add(cat1);
            Person cat2 = new Person();
            cat2.personID = 2;
            cat2.personName = "Hugo";
            cat2.personSurname = "HO";
            cat2.dateOfBirth = new DateTime(2028, 3, 4, 8, 30, 52);
            cat2.personMovies = "Cars";
            cat2.personRole = "Director";
            prod1.People.Add(cat2);
            context.Movies.Add(prod1);

            //Movie prod2 = new Movie();
            //prod2.MovieID = 2;

            //prod2.MovieName = "Fast and Furious 261";
            //prod2.Description = "More terrible car wrecks";
            //prod2.CategoryName = "Horror";
            //prod2.Rating = 7.0f;
            //prod2.personID = 2;
            //context.Movies.Add(prod2);

            base.Seed(context);
        }

    }
}