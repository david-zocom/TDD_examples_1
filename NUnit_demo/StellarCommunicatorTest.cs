using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TDD_examples_1.implementations;
using Moq;

namespace NUnit_demo
{

    [TestFixture]
    public class StellarCommunicatorTest
    {
        private StellarCommunicator sc;

        [SetUp]
        public void SetUp()
        {
            sc = new StellarCommunicator();
        }

        [Test]
        [TestCase(double.NaN, "address", "message")]
        [TestCase(double.PositiveInfinity, "address", "message")]
        [TestCase(double.NegativeInfinity, "address", "message")]
        [TestCase(double.MinValue, "address", "message")]
        [TestCase(-0.0, "address", "message")]
        [TestCase(150.0, null, "message")]
        [TestCase(150.0, "", "message")]
        [TestCase(150.0, "address", null)]
        [TestCase(150.0, "address", "")]
        public void SendMessage_IncorrectValues_Throws(double distance,
            string spaceAddress, string message)
        {
            //ChooseRangeCom
            Assert.That(() => sc.SendMessage(distance,
               spaceAddress, message), Throws.TypeOf<Exception>());
        }

        // short range message, success
        // short range message, fail
        // long range message, success
        // long range message, fail
        [Test]
        public void SendMessage_ShortRange_Success()
        {
            var mockSR = new Mock<ISpaceRangeCom>();
            var mockLR = new Mock<ISpaceRangeCom>();

            sc.ChooseRangeType(mockSR.Object, mockLR.Object);

            bool result = sc.SendMessage(StellarCommunicator.ShortRangeMax,
                "Vintergatan", "We come in peace");

            Assert.That(result, Is.True);
        }
    }
}
