using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_examples_1.implementations
{
    public class DriverSystem
    {
        protected int? SpeedLimit = null;  // Nullable type

        // Example input: "B", 18 -> true, "B", 17 -> false, "C", 21 -> true, "C", 20 -> false
        // If licenseType is not a valid license this method should throw an exception
        public bool CanGet(string licenseType, int ageYears)
        {
            throw new NotImplementedException();
        }

        // If given a proper value, changes the speed limit to the new value
        public void SetSpeedLimit(int newLimit)
        {
            throw new NotImplementedException();
        }

        // Returns true or false depending on whether the speed is higher than the limit
        public bool IsSpeeding(int speed)
        {
            throw new NotImplementedException();
        }
    }

    // Represents an invalid speed value
    public class BadSpeedException : Exception { }
}
