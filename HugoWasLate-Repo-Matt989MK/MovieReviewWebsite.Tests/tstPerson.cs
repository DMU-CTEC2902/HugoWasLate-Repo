using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieReviewWebsite.Models;

namespace MovieReviewWebsite.Tests
{
    [TestClass]
    public class tstPerson
    {
        [TestMethod]
        public void PersonIDPropertyOK()
        {

            //create an instance of the class we want to create
            Person APerson = new Person();
            //create some test data to assign to the property
            Int32 TestData = 1;
            //assign the data to the property
            APerson.personID = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(APerson.personID, TestData);
        }

        [TestMethod]
        public void PersonNamePropertyOK()
        {
            //create an instance of the class we want to create
            Person APerson = new Person();
            //create some test data to assign to the property
            string TestData = "AAA";
            //assign the data to the property
            APerson.personName = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(APerson.personName, TestData);
        }

        [TestMethod]
        public void PersonSurnamePropertyOK()
        {
            //create an instance of the class we want to create
            Person APerson = new Person();
            //create some test data to assign to the property
            string TestData = "BBB";
            //assign the data to the property
            APerson.personSurname = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(APerson.personSurname, TestData);
        }

        [TestMethod]
        public void DateOfBirthPropertyOK()
        {
            //create an instance of the class we want to create
            Person APerson = new Person();
            //create some test data to assign to the property
            DateTime TestData = DateTime.Now.Date;
            //assign the data to the property
            APerson.dateOfBirth = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(APerson.dateOfBirth, TestData);
        }

        [TestMethod]
        public void PersonRolePropertyOK()
        {
            //create an instance of the class we want to create
            Person APerson = new Person();
            //create some test data to assign to the property
            string TestData = "Actor";
            //assign the data to the property
            APerson.personRole = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(APerson.personRole, TestData);
        }

        [TestMethod]
        public void UserPropertyOK()
        {
            //create an instance of the class we want to create
            Person APerson = new Person();
            //create some test data to assign to the property
            string TestData = "Actor";
            //assign the data to the property
            APerson.User = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(APerson.User, TestData);
        }
    }
}
