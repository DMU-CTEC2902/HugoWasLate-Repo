using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieReviewWebsite.Models;

namespace MovieReviewWebsite.Tests
{
    [TestClass]
    public class tstComments
    {
        [TestMethod]
        public void AuthorIDPropertyOK()
        {

            //create an instance of the class we want to create
            Comment AComment = new Comment();
            //create some test data to assign to the property
            string TestData = "122";
            //assign the data to the property
            AComment.AuthorID = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AComment.AuthorID, TestData);
        }

        [TestMethod]
        public void CommentIDPropertyOK()
        {
            //create an instance of the class we want to create
            Comment AComment = new Comment();
            //create some test data to assign to the property
            Int32 TestData = 11;
            //assign the data to the property
            AComment.CommentID = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AComment.CommentID, TestData);
        }

        [TestMethod]
        public void PersonIDPropertyOK()
        {
            //create an instance of the class we want to create
            Comment AComment = new Comment();
            //create some test data to assign to the property
            Int32 TestData = 1;
            //assign the data to the property
            AComment.PersonID = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AComment.PersonID, TestData);
        }

        [TestMethod]
        public void MovieIDPropertyOK()
        {
            //create an instance of the class we want to create
            Comment AComment = new Comment();
            //create some test data to assign to the property
            Int32 TestData = 11;
            //assign the data to the property
            AComment.MovieID = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AComment.MovieID, TestData);
        }

        [TestMethod]
        public void PostIDPropertyOK()
        {
            //create an instance of the class we want to create
            Comment AComment = new Comment();
            //create some test data to assign to the property
            Int32 TestData = 11;
            //assign the data to the property
            AComment.PostID = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AComment.PostID, TestData);
        }

        [TestMethod]
        public void ContentPropertyOK()
        {
            //create an instance of the class we want to create
            Comment AComment = new Comment();
            //create some test data to assign to the property
            string TestData = "this is a test";
            //assign the data to the property
            AComment.Content = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AComment.Content, TestData);
        }

        [TestMethod]
        public void UserRatingPropertyOK()
        {
            //create an instance of the class we want to create
            Comment AComment = new Comment();
            //create some test data to assign to the property
            float TestData = 12;
            //assign the data to the property
            AComment.UserRating = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AComment.UserRating, TestData);
        }


    }

}
