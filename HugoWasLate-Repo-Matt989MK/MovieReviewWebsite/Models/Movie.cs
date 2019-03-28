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
        [Required]
        public virtual string CategoryName { get; set; }
        [Required]
        public virtual string MovieName { get; set; }
        [Required]
        public virtual string Description { get; set; }
        [RegularExpression(@"^\d+\.?\d{0,5}$")]
        [Range(0,10)]
        [Required]
        public virtual float Rating { get; set; }
        
        public virtual float AverageRating { get; set; }

        public virtual List<Person> People { get; set; }
        public virtual List<Comment> Comment { get; set; }//added this

        public virtual string User { get; set; }



    }
}