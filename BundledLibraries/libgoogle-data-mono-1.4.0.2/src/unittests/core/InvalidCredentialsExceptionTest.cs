﻿using Google.GData.Client;
using NUnit.Framework;
using Google.GData.Client.UnitTests;

    
    

namespace Google.GData.Client.UnitTests.Core
{
    
    
    /// <summary>
    ///This is a test class for InvalidCredentialsExceptionTest and is intended
    ///to contain all InvalidCredentialsExceptionTest Unit Tests
    ///</summary>
    [TestFixture][Category("CoreClient")]
    public class InvalidCredentialsExceptionTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for InvalidCredentialsException Constructor
        ///</summary>
        [Test]
        public void InvalidCredentialsExceptionConstructorTest1()
        {
            InvalidCredentialsException target = new InvalidCredentialsException();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for InvalidCredentialsException Constructor
        ///</summary>
        [Test]
        public void InvalidCredentialsExceptionConstructorTest()
        {
            string msg = "TestValue"; // TODO: Initialize to an appropriate value
            InvalidCredentialsException target = new InvalidCredentialsException(msg);
            Assert.IsNotNull(target);
            Assert.AreEqual(msg, target.Message);
        }
    }
}
