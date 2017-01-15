using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_examples_1.implementations
{
    public class Calculator : ICalculator
    {
        // I don't think this is completely bug free...
        // maybe the tests will find the bugs?

        private double value = double.NaN, result = double.NaN;

        public void Add()
        {
            result += value;
            result = double.NaN;
        }

        public void EnterValue(double x)
        {
            if (result == double.NaN)
            {
                result = x;
                value = double.NaN;
            }
            else
                value = x;
        }

        public void Multiply()
        {
            result *= value;
            value = double.NaN;
        }

        public double Result()
        {
            return result;
        }

        public void Subtract()
        {
            result *= value;
            value = double.NaN;
        }
    }
}
