using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_examples_1.implementations
{
    public class Cooling : ICooling
    {
        public bool IsWaterBoiling(float degreesCelsius)
        {
            return degreesCelsius >= 100.0f;
        }

        public bool IsWaterBoiling(float temperature, string scale)
        {
            if (scale == "fahrenheit")
                return temperature >= 212.0f;
            else if (scale == "celsius")
                return temperature >= 100.0f;
            throw new BadTemperatureException();
        }
    }
}
