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
          
           

            Forum forum1 = new Forum();
            forum1.postID = 1;
            forum1.postTitle = "What's the name of song nr3 in Madagascar";
            forum1.postContent = "It starts with nananan";
            forum1.postAuthorID = "1";
            forum1.CategoryName = "Horror";
          
            context.Fora.Add(forum1);


            base.Seed(context);
        }

    }
}
