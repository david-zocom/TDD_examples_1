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
    public class CoolingTest
    {
        [TestMethod]
        public void HighTemperatureIsBoiling()
        {
            float high = 200.0f;
            //float.PositiveInfinity
            Cooling c = new Cooling();
            bool result = c.IsWaterBoiling(high);
            Assert.AreEqual(true, result,
                "Failed to boil at " + high + " degrees");

            high = 100.0f;
            result = c.IsWaterBoiling(high);
            Assert.AreEqual(true, result,
                "FAiled to boil at " + high + " degrees");
        }
        [TestMethod]
        public void LowTemperatureIsNotBoiling()
        {
            float low = 20.0f;
            Cooling c = new Cooling();
            bool result = c.IsWaterBoiling(low);
            Assert.AreEqual(false, result,
                "Boiled at " + low + " degrees");

            low = 99.9999f;
            result = c.IsWaterBoiling(low);
            Assert.AreEqual(false, result,
                "Boiled at " + low + " degrees");
        }

        public void BadTemperature_NaN()
        {
            Assert.Fail();
            // todo: skriv kod som testar att ett
            // exception kastas om parametern
            // temperature är +Inf, -Inf eller NaN
            // - vi går igenom exceptions på onsdag!
        }
    }
}
