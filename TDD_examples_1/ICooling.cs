using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_examples_1
{
    public interface ICooling
    {
        // Returns true if water would be boiling at the specified temperature
        // Throws an exception on illegal input
        bool IsWaterBoiling(float degreesCelsius);

        // Returns true if water would be boiling at the specified temperature
        // "scale" should be either "Celsius" or "Fahrenheit"
        // Throws an exception on illegal input
        bool IsWaterBoiling(float temperature, string scale);
    }

    public class BadTemperatureException : Exception
    {
        public BadTemperatureException(string msg) : base(msg) { }
    }
}
