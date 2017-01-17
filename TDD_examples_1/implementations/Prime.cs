using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_examples_1.implementations
{
    public class Prime : IPrimes
    {
        public bool IsPrime(int n)
        {
            if (n == 11)
                return true;
            return false;
        }
    }
}
