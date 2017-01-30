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
        [TestCase(-0.0001, "address", "message")]
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

        [Test]
        public void SendMessage_ShortRange_Success()
        {
            var mockSR = new Mock<ISpaceRangeCom>();
            var mockLR = new Mock<ISpaceRangeCom>();
            //mockSR.Setup(x => x.SendMessage("Vintergatan",
            //    "We come in peace")).Returns(true);
            mockSR.Setup(x => x.SendMessage(It.IsAny<string>(),
                It.IsAny<string>())).Returns(true);
            sc.ChooseRangeType(mockSR.Object, mockLR.Object);

            bool result = sc.SendMessage(StellarCommunicator.ShortRangeMax,
                "Vintergatan", "We come in peace");

            Assert.That(result, Is.True);
            mockSR.Verify(x => x.SendMessage(
                    "Vintergatan",
                    It.Is<string>(y => !string.IsNullOrEmpty(y))),
                Times.Exactly(1));
            //Times.Between(1, 3, Range.Inclusive));
        }
        [Test]
        public void SendMessage_ShortRange_Fail()
        {
            var mockSR = new Mock<ISpaceRangeCom>();
            var mockLR = new Mock<ISpaceRangeCom>();
            mockSR.Setup(x => x.SendMessage(It.IsAny<string>(),
                It.IsAny<string>())).Returns(false);
            sc.ChooseRangeType(mockSR.Object, mockLR.Object);

            bool result = sc.SendMessage(StellarCommunicator.ShortRangeMax,
                "Vintergatan", "We come in peace");

            Assert.That(result, Is.False);
            mockSR.Verify(x => x.SendMessage(
                    "Vintergatan",
                    It.Is<string>(y => !string.IsNullOrEmpty(y))),
                Times.Exactly(StellarCommunicator.NumberOfTries));
        }
        [Test]
        public void SendMessage_LongRange_Success()
        {
            var mockSR = new Mock<ISpaceRangeCom>();
            var mockLR = new Mock<ISpaceRangeCom>();
            mockLR.Setup(x => x.SendMessage(It.IsAny<string>(),
                It.IsAny<string>())).Returns(true);
            sc.ChooseRangeType(mockSR.Object, mockLR.Object);

            bool result = sc.SendMessage(
                StellarCommunicator.ShortRangeMax + 1,
                "Vintergatan", "We come in peace");

            Assert.That(result, Is.True);
            mockLR.Verify(x => x.SendMessage(
                    "Vintergatan",
                    It.Is<string>(y => !string.IsNullOrEmpty(y))),
                Times.Exactly(1));
        }
        [Test]
        public void SendMessage_LongRange_Fail()
        {
            var mockSR = new Mock<ISpaceRangeCom>();
            var mockLR = new Mock<ISpaceRangeCom>();
            mockLR.Setup(x => x.SendMessage(It.IsAny<string>(),
                It.IsAny<string>())).Returns(false);
            sc.ChooseRangeType(mockSR.Object, mockLR.Object);

            bool result = sc.SendMessage(
                StellarCommunicator.ShortRangeMax + 1,
                "Vintergatan", "We come in peace");

            Assert.That(result, Is.False);
            mockLR.Verify(x => x.SendMessage(
                    "Vintergatan",
                    It.Is<string>(y => !string.IsNullOrEmpty(y))),
                Times.Exactly(StellarCommunicator.NumberOfTries));
        }
        // long range message, success
        // long range message, fail

    }
}
