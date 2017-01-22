using System;
using NUnit.Framework;

namespace DemoTest
{
    [TestFixture]
    public class NUnit_demo
    {
        [Test]
        public void BasicTest()
        {
            Assert.That(1 + 1 == 2, "Simple addition doesn't work");
            Assert.That(1 + 1, Is.EqualTo(2), "Simple addition doesn't work");

            Assert.IsEmpty("", "The string should be empty");

            Assert.IsNaN(double.NaN, "Cannot test not-a-number");
        }

        [Test]
        public void AlwaysFail()
        {
            Assert.Fail("Not ok!");
        }
        [Test]
        public void IgnoreTest()
        {
            Assert.Ignore("We don't care about the result of this test");
        }
        [Test]
        public void AlwaysPass()
        {
            Assert.Pass("Feeling generous today");
        }

        [Test]
        public void Exceptions()
        {
            Exception e = Assert.Throws<NullReferenceException>(
                new TestDelegate(MethodThatThrows), "The method didn't throw an exception");
            Assert.That(e.Message, Is.EqualTo(exceptionMessage));
        }
        private static string exceptionMessage = "some message";
        private void MethodThatThrows()
        {
            throw new NullReferenceException(exceptionMessage);
        }

        [TestCase(1, 1, ExpectedResult = 2)]
        [TestCase(2, 4, ExpectedResult = 5)]
        public int AdditionTest(int x, int y)
        {
            // Testmetoden kommer att anropas en gång för varje TestCase
            return x + y;
        }
    }
}
