using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieReviewWebsite.Models;
using MovieReviewWebsite.Models;


namespace MovieReviewWebsite.Tests
{
    [TestClass]
    public class tstMovie
    {
        //good test data
        //create some test data to pass to the method
        string personName = "aaa";
        string personSurname = "aaa";
        DateTime dateOfBirth = DateTime.Today;
        string personRole = "aaa";
        string User = "aaa";


        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the calss we want to create
            Movie AMovie = new Movie();
            //test to see that it exists
            Assert.IsNotNull(AMovie);
        }
        [TestMethod]
        public void CategoryNamePropertyOK()
        {
            //create an instance of the class we want to create 
            Movie AMovie = new Movie();
            //create some test data to assign to the property
            string TestData = "Action";
            AMovie.CategoryName = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AMovie.CategoryName, TestData);
        }
        [TestMethod]
        public void MovieNamePropertyOK()
        {
            //create an instance of the class we want to create 
            Movie AMovie = new Movie();
            //create some test data to assign to the property
            string TestData = "Action";
            AMovie.MovieName = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AMovie.MovieName, TestData);
        }
        [TestMethod]
        public void DescriptionPropertyOK()
        {
            //create an instance of the class we want to create 
            Movie AMovie = new Movie();
            //create some test data to assign to the property
            string TestData = "Action";
            AMovie.Description = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AMovie.Description, TestData);
        }
        [TestMethod]
        public void RatingPropertyOK()
        {
            //create an instance of the class we want to create 
            Movie AMovie = new Movie();
            //create some test data to assign to the property
            float TestData = 10;
            AMovie.Rating = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AMovie.Rating, TestData);
        }
        //[TestMethod]
        //public void PeoplePropertyOK()
        //{
        //    //create an instance of the class we want to create 
        //    Movie AMovie = new Movie();
        //    //create some test data to assign to the property
        //    Person person = new Person {personID=1,personName="aaa",personSurname="aaa",dateOfBirth = DateTime.Today,personRole = "aaa",Movies = {AMovie.MovieID=1,AMovie.MovieName="" },Comment="aaa",User="aaa" };
        //    AMovie.People = TestData;
        //    //test to see that the two values are the same
        //    Assert.AreEqual(AMovie.People, TestData);
        //}
        [TestMethod]
        public void UserPropertyOK()
        {
            //create an instance of the class we want to create 
            Movie AMovie = new Movie();
            //create some test data to assign to the property
            float TestData = 10;
            AMovie.Rating = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AMovie.Rating, TestData);
        }


    }
}
