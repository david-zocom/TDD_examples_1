using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_examples_1.implementations
{
    public class DriverSystem
    {
        // Nullable type
        public int? SpeedLimit { get; private set; } = null;
        // Example input: "B", 18 -> true, "B", 17 -> false, 
        // "C", 21 -> true, "C", 20 -> false
        // If licenseType is not a valid license this method 
        // should throw an exception
        public bool CanGet(string licenseType, int ageYears)
        {
            if (licenseType != "B" && licenseType != "C")
                throw new Exception();
            if (ageYears < 0)
                throw new Exception();

            if (licenseType == "B")
                return ageYears >= 18;
            else //if (licenseType == "C")
                return ageYears >= 21;
        }

        // If given a proper value, changes the speed limit
        // to the new value
        // Must be positive number 1 <= x <= 200
        public void SetSpeedLimit(int newLimit)
        {
            if (newLimit < 1 || newLimit > 200)
                throw new BadSpeedException();
            SpeedLimit = newLimit;
        }

        // Returns true or false depending on whether the 
        // speed is higher than the limit
        public bool IsSpeeding(int speed)
        {
            if (!SpeedLimit.HasValue)
                throw new NullReferenceException();
            if (speed < 0)
                throw new BadSpeedException();
            return speed > SpeedLimit;
        }
    }

    // Represents an invalid speed value
    public class BadSpeedException : Exception { }
}
