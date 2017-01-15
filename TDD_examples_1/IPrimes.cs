using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_examples_1
{
    public interface IPrimes
    {
        // Returns true if n is a prime number: 2, 3, 5, 7, 11, ...
        bool IsPrime(int n);
    }
}
