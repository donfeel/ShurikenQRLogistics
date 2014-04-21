using Shuriken.Weixin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Shuriken.Weixin.Test
{
    
    
    /// <summary>
    ///This is a test class for CheckSignatureTest and is intended
    ///to contain all CheckSignatureTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CheckSignatureTest
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
        ///A test for Get
        ///</summary>
        [TestMethod()]
        public void GetTest()
        {
            {
                var signature = "bd18cc0c442ce7f5030dd4c88963b0a98a6c7057";
                var echostr = "1392345180215823675";
                var timestamp = "1398064395";
                var nonce = "1054823587";
                var token = "ShurikenWX";

                CheckSignature.IsValid(signature, timestamp, nonce, token);
                var result = CheckSignature.GetLocal();
                Assert.AreEqual(signature, result);
            }
        }
    }
}
