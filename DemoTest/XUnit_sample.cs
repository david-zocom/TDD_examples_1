using System;
using Xunit;

namespace DemoTest
{
    public class XUnit_sample
    {
        [Fact]
        public void TestMethod1()
        {
            Assert.True(1 + 1 == 2, "Basic arithmetic should succeed");
            Assert.Equal("hej", "HEJ", true);
        }
    }
}
