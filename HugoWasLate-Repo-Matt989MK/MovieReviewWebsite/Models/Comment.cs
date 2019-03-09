using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieReviewWebsite.Models
{
    public class Comment
    {
        public virtual int ID { get; set; }
        public virtual int AuthorID { get; set; }
        public virtual int PersonID { get; set; }
        public virtual int PostID { get; set; }
        public virtual string Content { get; set; }
    }
}