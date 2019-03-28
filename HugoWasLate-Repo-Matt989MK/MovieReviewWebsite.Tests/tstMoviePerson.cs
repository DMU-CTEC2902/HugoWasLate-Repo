using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieReviewWebsite.Models;

namespace MovieReviewWebsite.Tests
{
    [TestClass]
    public class tstMoviePerson
    {

        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the calss we want to create
            MoviePerson AMoviePerson = new MoviePerson();
            //test to see that it exists
            Assert.IsNotNull(AMoviePerson);
        }
        [TestMethod]
        public void MovieIDPropertyOK()
        {
            //create an instance of the class we want to create 
            MoviePerson AMoviePerson = new MoviePerson();
            //create some test data to assign to the property
            int TestData = 1;
            AMoviePerson.MovieID = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AMoviePerson.MovieID, TestData);
        }
        [TestMethod]
        public void personIDPropertyOK()
        {
            //create an instance of the class we want to create 
            MoviePerson AMoviePerson = new MoviePerson();
            //create some test data to assign to the property
            int TestData = 1;
            AMoviePerson.personID = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AMoviePerson.personID, TestData);
        }
       
    }
}
