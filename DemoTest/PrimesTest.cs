using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_examples_1;
using TDD_examples_1.implementations;

namespace DemoTest
{
    [TestClass]
    public class PrimesTest
    {
        [TestMethod]
        public void NumberIsPrimeTest()
        {
            IPrimes p = new Prime();
            int n = 11;
            bool result = p.IsPrime(n);
            Assert.AreEqual(true, result,
                "Funktionen förstår inte att 11 är ett primtal");
            n = 5;
            result = p.IsPrime(n);
            Assert.AreEqual(true, result,
                "Funktionen förstår inte att 5 är ett primtal");
        }
        [TestMethod]
        public void NumberIsNotPrimeTest()
        {
            Prime p = new Prime();
            int n = 10;
            bool result = p.IsPrime(n);
            Assert.AreEqual(false, result,
                "Funktionen tror att 10 är ett primtal");
        }
    }
}
