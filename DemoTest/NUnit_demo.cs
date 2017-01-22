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
    }
}
