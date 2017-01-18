using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_examples_1.implementations
{
    public class Roman : IRoman
    {
        public string IntToRoman(int number)
        {
            if (number > 3999 || number < 1)
                throw new ArgumentOutOfRangeException();

            // IVXLCDM
            string result = "";
            while (number > 0)
            {
                if (number >= 1000)
                {
                    result += "M";
                    number -= 1000;
                }
                else if (number >= 900)
                {
                    result += "CM";
                    number -= 900;
                }
                else if (number >= 500)
                {
                    result += "D";
                    number -= 500;
                }
                else if (number >= 400)
                {
                    result += "CD";
                    number -= 400;
                }
                else if (number >= 100)
                {
                    result += "C";
                    number -= 100;
                }
                else if (number >= 90)
                {
                    result += "XC";
                    number -= 90;
                }
                else if (number >= 50)
                {
                    result += "L";
                    number -= 50;
                }
                else if (number >= 40)
                {
                    result += "XL";
                    number -= 40;
                }
                else if (number >= 10)
                {
                    result += "X";
                    number -= 10;
                }
                else if (number >= 9)
                {
                    result += "IX";
                    number -= 9;
                }
                else if (number >= 5)
                {
                    result += "V";
                    number -= 5;
                }
                else if (number >= 4)
                {
                    result += "IV";
                    number -= 4;
                }
                else if (number >= 1)
                {
                    result += "I";
                    number -= 1;
                }
            }
            return result;
        }

        public int RomanToInt(string number)
        {
            throw new NotImplementedException();
        }
    }
}
