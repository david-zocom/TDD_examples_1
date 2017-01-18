using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_examples_1.implementations;

namespace DemoTest
{
    /// <summary>
    /// Summary description for RomanTest
    /// </summary>
    [TestClass]
    public class RomanTest
    {
        public RomanTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AllowedNumberIsCorrectTest()
        {
            Roman r = new Roman();
            int x = 2017;
            string expected = "MMXVII";
            string actual = r.IntToRoman(x);
            Assert.AreEqual(expected, actual,
                "Wrong roman number for " + x);

            RomanHelper(r, 3999, "MMMCMXCIX");
            RomanHelper(r, 1, "I");
            RomanHelper(r, 21, "XXI");
            RomanHelper(r, 400, "CD");
            RomanHelper(r, 444, "CDXLIV");
            RomanHelper(r, 43, "XLIII");
            RomanHelper(r, 443, "CDXLIII");
        }
        private void RomanHelper(Roman r, int x, string expected)
        {
            string actual = r.IntToRoman(x);
            Assert.AreEqual(expected, actual,
                "Wrong roman number for " + x);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DisallowedNumberThrowsException_4000()
        {
            Roman r = new Roman();
            r.IntToRoman(4000);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DisallowedNumberThrowsException_0()
        {
            Roman r = new Roman();
            r.IntToRoman(0);
        }
    }
}
