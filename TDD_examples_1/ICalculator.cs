using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_examples_1
{
    public interface ICalculator
    {
        void EnterValue(double x);
        void Add();
        void Subtract();
        void Multiply();
        double Result();
    }
}
