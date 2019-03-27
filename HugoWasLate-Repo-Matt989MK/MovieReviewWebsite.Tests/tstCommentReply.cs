using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieReviewWebsite.Models;

namespace MovieReviewWebsite.Tests
{
    [TestClass]
    public class tstCommentReply
    {
       

        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the calss we want to create
            CommentReply AReply = new CommentReply();
            //test to see that it exists
            Assert.IsNotNull(AReply);
        }
        [TestMethod]
        public void CommentReplyIDPropertyOK()
        {
            //create an instance of the class we want to create 
            CommentReply AReply = new CommentReply();
            //create some test data to assign to the property
            int TestData = 1;
            AReply.CommentID = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AReply.CommentID, TestData);
        }
        [TestMethod]
        public void AuthorIDPropertyOK()
        {
            //create an instance of the class we want to create 
            CommentReply AReply = new CommentReply();
            //create some test data to assign to the property
            string TestData = "aaa";
            AReply.AuthorID = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AReply.AuthorID, TestData);
        }
        [TestMethod]
        public void PersonIDPropertyOK()
        {
            //create an instance of the class we want to create 
            CommentReply AReply = new CommentReply();
            //create some test data to assign to the property
            int TestData = 1;
            AReply.PersonID = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AReply.PersonID, TestData);
        }
        [TestMethod]
        public void MovieIDPropertyOK()
        {
            //create an instance of the class we want to create 
            CommentReply AReply = new CommentReply();
            //create some test data to assign to the property
            int TestData = 10;
            AReply.MovieID = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AReply.MovieID, TestData);
        }
       
        [TestMethod]
        public void PostIDPropertyOK()
        {
            //create an instance of the class we want to create 
            CommentReply AReply = new CommentReply();
            //create some test data to assign to the property
            int TestData = 10;
            AReply.PostID = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AReply.PostID, TestData);
        }
        [TestMethod]
        public void ContentPropertyOK()
        {
            //create an instance of the class we want to create 
            CommentReply AReply = new CommentReply();
            //create some test data to assign to the property
            string TestData = "aaa";
            AReply.Content = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AReply.Content, TestData);
        }
    }
}
