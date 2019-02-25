using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MovieReviewWebsite.Models
{
    [Table("postdetails")]
    public class Forum
    {
        [Key]
         public virtual int postID { get; set; }
        public virtual string postTitle { get; set; }
        public virtual string postContent { get; set; }
        public virtual string postAuthorID { get; set; }
        public virtual int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}