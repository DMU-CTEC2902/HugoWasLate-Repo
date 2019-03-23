﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MovieReviewWebsite.Models
{
    [Table("persons")]
    public class Person
    {
        [Key]
        public virtual int personID { get; set; }
        public virtual string personName { get; set; }
        public virtual string personSurname { get; set; }
        public virtual DateTime dateOfBirth { get; set; }
        public virtual string personRole { get; set; }
        public virtual List<Movie> Movies { get; set; }
        public virtual List<Comment> Comment { get; set; }
        public virtual List<CommentReply> CommentReply { get; set; }
    }
}