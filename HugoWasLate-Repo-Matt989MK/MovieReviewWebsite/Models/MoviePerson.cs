using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieReviewWebsite.Models
{
    public class MoviePerson
    {
        public virtual int MoviePersonId { get; set; }
        public virtual int MovieID { get; set; }
        public virtual int personID { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Person Person { get; set; }
    }
}