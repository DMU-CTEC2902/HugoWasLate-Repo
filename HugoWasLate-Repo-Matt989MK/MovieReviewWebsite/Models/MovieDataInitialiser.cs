using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MovieReviewWebsite.Models
{
    public class MovieDataInitialiser: DropCreateDatabaseAlways<MovieContext>
    {
        protected override void Seed(MovieContext context)
        {
            //------------------------------------- PEOPLE
            Person cat1 = new Person();
            cat1.personID = 1;
            cat1.personName = "Lala";
            cat1.personSurname = "fsafsa";
            cat1.dateOfBirth = new DateTime(2008, 5, 1, 8, 30, 52);
            cat1.personRole = "Actor";
            context.People.Add(cat1);
    
            Person cat2 = new Person();
            cat2.personID = 2;
            cat2.personName = "hugo";
            cat2.personSurname = "HO";
            cat2.dateOfBirth = new DateTime(2028, 3, 4, 8, 30, 52);
          
            cat2.personRole = "Director";
            context.People.Add(cat2);


            Person p1 = new Person();//p1=person1
            p1.personID = 3;
            p1.personName = "Bob";
            p1.personSurname = "Marley";
            p1.dateOfBirth = new DateTime(2008, 5, 1, 8, 30, 52);
         
            p1.personRole = "Actor";
            context.People.Add(p1);

            Person p2 = new Person();//p2=person2
            p2.personID = 4;
            p2.personName = "Alf";
            p2.personSurname = "HO";
            p2.dateOfBirth = new DateTime(2028, 3, 4, 8, 30, 52);
            p2.personRole = "Director";
            context.People.Add(p2);


            //------------------------------------------------- MOVIES
            Movie prod1 = new Movie();
            prod1.MovieID = 1;
            prod1.MovieName = "Cars";
            prod1.Description = "Animated movie";
            prod1.CategoryName = "Horror";
            prod1.Rating = 3.0f;
            context.Movies.Add(prod1);

            Movie prod3 = new Movie();
            prod3.MovieID = 3;
            prod3.MovieName = "Shrek in the swamp";
            prod3.Description = "Animal Documentary";
            prod3.CategoryName = "Romance";
            prod3.Rating = 10.0f;
            prod3.People = new List<Person>();
            context.Movies.Add(prod3);


            Movie prod2 = new Movie();
            prod2.MovieID = 2;
            prod2.MovieName = "Fast and Furious 261";
            prod2.Description = "More terrible car wrecks";
            prod2.CategoryName = "Comedy";
            prod2.Rating = 7.0f;
            context.Movies.Add(prod2);
            

            //----------------------------------------- MOVIEPERSON
            MoviePerson mp = new MoviePerson();
            mp.MoviePersonId = 1;
            mp.MovieID = 1;
            mp.personID = 3;
            context.MoviePerson.Add(mp);


            MoviePerson mp1 = new MoviePerson();
            mp1.MoviePersonId = 2;
            mp1.MovieID = 1;
            mp1.personID = 1;
            context.MoviePerson.Add(mp1);

            MoviePerson mp2 = new MoviePerson();
            mp2.MoviePersonId = 3;
            mp2.MovieID = 2;
            mp2.personID = 4;
            context.MoviePerson.Add(mp2);

            MoviePerson mp3 = new MoviePerson();
            mp3.MoviePersonId = 4;
            mp3.MovieID = 3;
            mp3.personID = 4;
            context.MoviePerson.Add(mp3);

            MoviePerson mp4 = new MoviePerson();
            mp4.MoviePersonId = 5;
            mp4.MovieID = 3;
            mp4.personID = 3;
            context.MoviePerson.Add(mp4);

            MoviePerson mp5 = new MoviePerson();
            mp5.MoviePersonId = 6;
            mp5.MovieID = 1;
            mp5.personID = 2;
            context.MoviePerson.Add(mp5);
            //------------------------------------------------------ COMMENTS
            Comment com1 = new Comment();
            com1.CommentID = 1;
            com1.AuthorID = 1;
            com1.Content = "A really good actor ";
            com1.PersonID = 1;
            com1.MovieID = 1;
            com1.PostID = 1;
            context.Comment.Add(com1);

            Comment com2 = new Comment();
            com2.CommentID = 2;
            com2.AuthorID = 1;
            com2.Content = "So talented! ";
            com2.PersonID = 2;
            com2.MovieID = 1;
            com2.PostID = 1;
            context.Comment.Add(com2);

            Comment com3 = new Comment();
            com3.CommentID = 3;
            //com3.AuthorID = 1;
            com3.Content = "So GOOD! ";
            com3.PersonID = 2;
            com3.MovieID = 2;
            com3.PostID = 1;
            context.Comment.Add(com3);

            Comment com4 = new Comment();
            com4.CommentID = 4;
            //com4.AuthorID = 1;
            com4.Content = "So BADDD! ";
            com4.PersonID = 1;
            com4.MovieID = 2;
            com4.PostID = 1;
            context.Comment.Add(com4);


            //------------------------------------------------------ Forums

            Forum foru1 = new Forum();
            foru1.PostID = 1;
            foru1.PersonID = 1;
            foru1.Title = "check this movie";
            foru1.PostTime = new DateTime(2028, 2, 14, 8, 30, 50);
            foru1.Content = "I think this movie is the best";
            foru1.LikeForums = 13;
            context.Forums.Add(foru1);


            Forum foru2 = new Forum();
            foru2.PostID = 2;
            foru2.PersonID = 2;
            foru2.Title = "check this aksjdnakjsdh movie";
            foru2.PostTime = new DateTime(2128, 12, 4, 8, 30, 50);
            foru2.Content = "I think this movie is the sadasdasdas best";
            foru2.LikeForums = 137;
            context.Forums.Add(foru2);

            //------------------------------------------------------ 

            base.Seed(context);

        }

    }
}