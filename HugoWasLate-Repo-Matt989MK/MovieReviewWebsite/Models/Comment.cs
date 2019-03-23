using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieReviewWebsite.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public virtual int CommentID { get; set; }
        public virtual int AuthorID { get; set; }
        public virtual int PersonID { get; set; }
        public virtual int MovieID { get; set; }//added this
        public virtual int PostID { get; set; }
        public virtual string Content { get; set; }
    }
}