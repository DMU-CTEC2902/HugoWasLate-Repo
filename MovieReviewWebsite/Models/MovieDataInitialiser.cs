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
            context.Movies.Add(prod1);

            Movie prod2 = new Movie();
            prod2.MovieID = 2;
            
            prod2.MovieName = "Fast and Furious 261";
            prod2.Description = "More terrible car wrecks";
            prod2.CategoryName = "Horror";
            prod2.Rating = 7.0f;
            prod2.personID = 2;
            context.Movies.Add(prod2);

            base.Seed(context);
        }

    }
}