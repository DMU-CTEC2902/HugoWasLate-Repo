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
            //prod1.personID = 1;
            prod1.People = new List<Person>();
            Person p1 = new Person();//p1=person1
            p1.personID = 1;
            p1.personName = "Bob";
            p1.personSurname = "Marley";
            p1.dateOfBirth = new DateTime(2008, 5, 1, 8, 30, 52);
            p1.movies= "Cars";
            p1.personRole = "Actor";
            prod1.People.Add(p1);
            Person p2 = new Person();//p2=person2
            p2.personID = 2;
            p2.personName = "Hugo";
            p2.personSurname = "HO";
            p2.dateOfBirth = new DateTime(2028, 3, 4, 8, 30, 52);
            p2.movies = "Cars";
            p2.personRole = "Director";
            prod1.People.Add(p2);
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