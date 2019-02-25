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
            Category cat1 = new Category();
            cat1.CategoryId = 1;
            cat1.Name = "Comedy";
            cat1.Description = "Music compact discs";
            context.Categories.Add(cat1);
            Category cat2 = new Category();
            cat2.CategoryId = 2;
            cat2.Name = "Horror";
            cat2.Description = "Film DVDs";
            context.Categories.Add(cat2);
            Movie prod1 = new Movie();
            prod1.MovieID = 1;
            prod1.CategoryId = 1;
            prod1.MovieName = "Now That's What I Call Music 261";
            prod1.Description = "More terrible hits";
            prod1.Category = cat1;
            context.Movies.Add(prod1);
            Movie prod2 = new Movie();
            prod2.MovieID = 2;
            prod2.CategoryId = 2;
            prod2.MovieName = "Fast and Furious 261";
            prod2.Description = "More terrible car wrecks";
            prod2.Category = cat2;
            context.Movies.Add(prod2);

            base.Seed(context);
        }

    }
}