using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_examples_1
{
    public interface IRoman
    {
        // Returns the parameter number as a string of roman numerals
        string IntToRoman(int number);

        // Returns the integer represented by the parameter roman numeral string
        int RomanToInt(string number);
    }
}
