using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MovieReviewWebsite.Models
{
    [Table("movies")]
    public class Movie
    {
        [Key]
        public virtual int MovieID { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual string MovieName { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal Price { get; set; }
        public virtual Category Category { get; set; }


    }
}