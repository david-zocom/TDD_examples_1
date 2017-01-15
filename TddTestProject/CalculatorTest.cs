using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_examples_1;
using TDD_examples_1.implementations;

namespace TddTestProject
{
    [TestClass]
    public class CalculatorTest
    {
        //[TestMethod]
        public void AddTwoNumbers()
        {
            ICalculator calc = new Calculator();
            calc.EnterValue(5);
            calc.EnterValue(10);
            var result = calc.Result();
            Assert.AreEqual(5 + 10, result, "Fel resultat vid Add, result="+result);
        }

        //[TestMethod]
        public void EnterSingleNumber()
        {
            double input = 2.0;
            Calculator calc = new Calculator();
            calc.EnterValue(input);
            var result = calc.Result();
            Assert.AreEqual(input, result, "EnterValue fail");
        }
    }
}
