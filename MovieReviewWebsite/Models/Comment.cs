using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MovieReviewWebsite.Models
{
    [Table("comments")]
    public class Comment
    {
        [Key]
         public virtual int postID { get; set; }
         public virtual int commentID { get; set; }
         public virtual string commentContent { get; set; }
    }
}