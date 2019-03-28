using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieReviewWebsite.Models
{
    [Table("Forums")]
    public class Forum
    {
        [Key]
        public virtual int PostID { get; set; }
        public virtual string UserID { get; set; }
        [Required]
        public virtual string Title { get; set; }
        [Required]
        public virtual DateTime PostTime { get; set; }
        [Required]
        public virtual string Content { get; set; }
        //public virtual string User { get; set; }
        public virtual List<Comment> Comment { get; set; }

    }
}