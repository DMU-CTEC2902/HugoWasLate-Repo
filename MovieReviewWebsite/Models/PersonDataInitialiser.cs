﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace MovieReviewWebsite.Models
{
    public class PersonDataInitialiser: DropCreateDatabaseAlways<PersonContext>
    {
        protected override void Seed(PersonContext context)
        {
            Person cat1 = new Person();
            cat1.personID= 1;
            cat1.personName = "Lala";
            cat1.personSurname = "fsafsa";
            cat1.dateOfBirth = new DateTime(2008, 5, 1, 8, 30, 52);
            cat1.personMovies = "Game of Thrones";
            cat1.personRole = "Actor";
            context.People.Add(cat1);
            
            base.Seed(context);
        }

    
}
}