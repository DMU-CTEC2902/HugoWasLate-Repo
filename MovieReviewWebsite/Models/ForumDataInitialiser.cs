using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace MovieReviewWebsite.Models
{
    public class ForumDataInitialiser: DropCreateDatabaseAlways<ForumContext>
    {
        protected override void Seed(ForumContext context)
        {
            Category cat1 = new Category();
            cat1.CategoryId = 1;
            cat1.Name = "Soundtrack";
            cat1.Description = "movie soundtrack post";
            context.Categories.Add(cat1);
            Category cat2 = new Category();
            cat2.CategoryId = 2;
            cat2.Name = "Location";
            cat2.Description = "movie location post";
            context.Categories.Add(cat2);

            Forum forum1 = new Forum();
            forum1.postID = 1;
            forum1.postTitle = "What's the name of song nr3 in Madagascar";
            forum1.postContent = "It starts with nananan";
            forum1.postAuthorID = "1";
            forum1.CategoryId = 1;
            forum1.Category = cat1;
            context.Fora.Add(forum1);


            base.Seed(context);
        }

    }
}
