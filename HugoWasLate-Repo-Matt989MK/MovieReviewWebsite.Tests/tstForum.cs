using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieReviewWebsite.Models;

namespace MovieReviewWebsite.Tests
{
    [TestClass]
    public class tstForum
    {
        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the calss we want to create
            Forum AForum = new Forum();
            //test to see that it exists
            Assert.IsNotNull(AForum);
        }
        [TestMethod]
        public void PersonIDPropertyOK()
        {
            //create an instance of the class we want to create 
            Forum AForum = new Forum();
            //create some test data to assign to the property
            int TestData = 1;
            AForum.PersonID = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AForum.PersonID, TestData);
        }
        [TestMethod]
        public void TitlePropertyOK()
        {
            //create an instance of the class we want to create 
            Forum AForum = new Forum();
            //create some test data to assign to the property
            string TestData = "aaa";
            AForum.Title = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AForum.Title, TestData);
        }
        [TestMethod]
        public void ContentPropertyOK()
        {
            //create an instance of the class we want to create 
            Forum AForum = new Forum();
            //create some test data to assign to the property
            string TestData = "2";
            AForum.Content = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AForum.Content, TestData);
        }
        [TestMethod]
        public void UserPropertyOK()
        {
            //create an instance of the class we want to create 
            Forum AForum = new Forum();
            //create some test data to assign to the property
            string TestData = "12";
            AForum.User = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AForum.User, TestData);
        }

        [TestMethod]
        public void PostTimePropertyOK()
        {
            //create an instance of the class we want to create 
            Forum AForum = new Forum();
            //create some test data to assign to the property
            int TestData = 01/01/1998;
            AForum.PostID = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AForum.PostID, TestData);
        }

    }
}
