using System;
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
            cat1.movies = "Game of Thrones";
            cat1.personRole = "Actor";
            context.People.Add(cat1);




            Person cat2 = new Person();
            cat2.personID = 2;
            cat2.personName = "hugo";
            cat2.personSurname = "HO";
            cat2.dateOfBirth = new DateTime(2028, 3, 4, 8, 30, 52);
            cat2.movies = "asadsadsadsad";
            cat2.personRole = "Director";
            context.People.Add(cat2);

            base.Seed(context);
        }

    
}
}