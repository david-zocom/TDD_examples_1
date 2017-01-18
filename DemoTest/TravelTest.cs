using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_examples_1.implementations;

namespace DemoTest
{
    [TestClass]
    public class TravelTest
    {
        private Travel t;

        public TravelTest()
        {
            t = new Travel();

        }

        [TestMethod]
        public void BookTrip_Success()
        {
            string destination = "island";
            bool result = t.BookTrip(destination);
            Assert.IsTrue(result, "Booking should succeed");
        }
        [TestMethod]
        public void BookTrip_Fail_IllegalParameter()
        {
            string destination = null;
            bool result = t.BookTrip(destination);
            Assert.IsFalse(result, "Booking to null should fail");

            destination = "";
            result = t.BookTrip(destination);
            Assert.IsFalse(result, "Booking to empty string should fail");
        }
        [TestMethod]
        public void BookTrip_Fail_SameOriginAndDestination()
        {
            string destination = "Göteborg";
            t.SetOrigin(destination);
            bool result = t.BookTrip(destination);
            Assert.IsFalse(result,
                "Booking trip between same origin/destination should fail");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetPosition_Fail_OriginNotSet()
        {
            t.GetPosition();
        }

        [TestMethod]
        public void GetPosition_Success()
        {
            string o = "Göteborg";
            t.SetOrigin(o);
            string d = t.GetPosition();
            Assert.AreEqual(o, d, "GetPosition wrong position");
        }

        [TestMethod]
        public void GoOnTrip_Success()
        {
            string o = "Göteborg", d = "Island";
            t.SetOrigin(o);
            t.BookTrip(d);
            bool result = t.GoOnTrip();
            Assert.IsTrue(result, "Trip should succeed");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GoOnTrip_Fail_EitherNotSet()
        {
            t.SetOrigin("Ankeborg");
            t.GoOnTrip();
        }


    }
}
