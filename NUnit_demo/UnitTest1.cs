using System;
// Ta bort referensen till MSTest
using NUnit.Framework;

namespace NUnit_demo
{
    [TestFixture]
    public class NUnit_demo
    {
        [Test]
        public void TestMethod1()
        {
            int actual = 10;
            Assert.That(actual, Is.LessThan(20), "error message");

            Exception e = Assert.Throws<Exception>(
                new TestDelegate(ExceptionCauser),
                "Missing exception");
            
        }
        private void ExceptionCauser()
        {
            throw new Exception();
        }

        [Test]
        [TestCase(8)]
        [TestCase(801)]
        [TestCase(8001)]
        [TestCase(221)]
        public void IsEven_Success(int x)
        {
            Assert.That(IsEven(x), Is.True);
            /*Assert.That(IsEven(8), Is.True);
            Assert.That(IsEven(80), Is.True);
            Assert.That(IsEven(800), Is.True);
            Assert.That(IsEven(22), Is.True);*/
        }

        private bool IsEven(int x)
        {
            return x % 2 == 0;
        }
    }
}
