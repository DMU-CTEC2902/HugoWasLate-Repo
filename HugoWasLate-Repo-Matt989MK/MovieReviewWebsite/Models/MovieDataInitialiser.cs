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

            Movie prod4 = new Movie();
            prod4.MovieID = 4;
            prod4.MovieName = "Avengers";
            prod4.Description = "Movie with all marvel heroes";
            prod4.CategoryName = "Action";
            prod4.Rating = 10f;
            context.Movies.Add(prod4);

            Movie prod5 = new Movie();
            prod5.MovieID = 5;
            prod5.MovieName = "Avengers: Age Of Ultron";
            prod5.Description = "2nd Movie with all marvel heroes";
            prod5.CategoryName = "Action";
            prod5.Rating = 9f;
            context.Movies.Add(prod5);

            Movie prod6 = new Movie();
            prod6.MovieID = 6;
            prod6.MovieName = "Titanic";
            prod6.Description = "Romance movie with Di Caprio";
            prod6.CategoryName = "Romance";
            prod6.Rating = 5f;
            context.Movies.Add(prod6);

            Movie prod7 = new Movie();
            prod7.MovieID = 7;
            prod7.MovieName = "The Nun";
            prod7.Description = "Scary movie prequel of The Conjuring";
            prod7.CategoryName = "Horror";
            prod7.Rating = 10f;
            context.Movies.Add(prod7);

            Movie prod8 = new Movie();
            prod8.MovieID = 8;
            prod8.MovieName = "Salim";
            prod8.Description = "Oscar nominated, movie about teacher giving top grades to students";
            prod8.CategoryName = "Comedy";
            prod8.Rating = 10f;
            context.Movies.Add(prod8);
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

            MoviePerson mp6 = new MoviePerson();
            mp6.MoviePersonId = 7;
            mp6.MovieID = 6;
            mp6.personID = 3;
            context.MoviePerson.Add(mp6);

            MoviePerson mp7 = new MoviePerson();
            mp7.MoviePersonId = 8;
            mp7.MovieID = 6;
            mp7.personID = 2;
            context.MoviePerson.Add(mp7);
            //------------------------------------------------------ COMMENTS
            Comment com1 = new Comment();
            com1.CommentID = 1;
            com1.AuthorID = "1";
            com1.Content = "1 A really good actor ";
            com1.PersonID = 1;
            com1.MovieID = 1;
            com1.PostID = 1;
            com1.isBlocked = false;
            com1.UserRating = 5.0f;
            context.Comment.Add(com1);

            Comment com2 = new Comment();
            com2.CommentID = 2;
            com2.AuthorID = "1";
            com2.Content = " 2 So talented! ";
            com2.PersonID = 2;
            com2.MovieID = 1;
            com2.PostID = 1;
            com2.isBlocked = false;
            com2.UserRating = 6.0f;
            context.Comment.Add(com2);

            Comment com3 = new Comment();
            com3.CommentID = 3;
            com3.AuthorID = "abc@gmail.com";
            com3.Content = " 3 So GOOD! ";
            com3.PersonID = 2;
            com3.MovieID = 1;
            com3.PostID = 1;
            com3.isBlocked = false; ;
            com3.UserRating = 4.0f;
            context.Comment.Add(com3);

            Comment com4 = new Comment();
            com4.CommentID = 4;
            com4.AuthorID = "1";
            com4.Content = "4 So BADDD! ";
            com4.PersonID = 1;
            com4.MovieID = 1;
            com4.PostID = 1;
            com1.isBlocked = true;
            com4.UserRating = 5.7f;
            context.Comment.Add(com4);


            //------------------------------------------------------ Forums

            Forum foru1 = new Forum();
            foru1.PostID = 1;
            foru1.UserID = 1;
            foru1.Title = "check this movie";
            foru1.PostTime = new DateTime(2028, 2, 14, 8, 30, 50);
            foru1.Content = "I think this movie is the best";
            context.Forums.Add(foru1);


            Forum foru2 = new Forum();
            foru2.PostID = 2;
            foru2.UserID = 2;
            foru2.Title = "check this aksjdnakjsdh movie";
            foru2.PostTime = new DateTime(2128, 12, 4, 8, 30, 50);
            foru2.Content = "I think this movie is the sadasdasdas best";
            context.Forums.Add(foru2);

            //------------------------------------------------------ 

            //-------------------------------------------------------------CommentReply
            CommentReply comReply = new CommentReply() { CommentID = 1, CommentReplyID = 1, AuthorID = "1", PersonID = 1, MovieID = 1, PostID = 1, Content = "this is a reply" };
            context.CommentReply.Add(comReply);
            CommentReply comReply1 = new CommentReply() { CommentID = 1, CommentReplyID = 2, AuthorID = "1", PersonID = 1, MovieID = 1, PostID = 1, Content = "reply1-2" };
            context.CommentReply.Add(comReply1);
            CommentReply comReply2 = new CommentReply() { CommentID = 1, CommentReplyID = 3, AuthorID = "1", PersonID = 1, MovieID = 1, PostID = 1, Content = "this is a reply1-3" };
            context.CommentReply.Add(comReply2);

            CommentReply comReply3 = new CommentReply() { CommentID = 2, CommentReplyID = 4, AuthorID = "1", PersonID = 1, MovieID = 1, PostID = 1, Content = "this is a reply" };
            context.CommentReply.Add(comReply3);
            CommentReply comReply4 = new CommentReply() { CommentID = 2, CommentReplyID = 5, AuthorID = "1", PersonID = 1, MovieID = 1, PostID = 1, Content = "reply1-2" };
            context.CommentReply.Add(comReply4);
            CommentReply comReply5 = new CommentReply() { CommentID = 2, CommentReplyID = 6, AuthorID = "1", PersonID = 1, MovieID = 1, PostID = 1, Content = "this is a reply1-3" };
            context.CommentReply.Add(comReply5);

            base.Seed(context);

        }

    }
}