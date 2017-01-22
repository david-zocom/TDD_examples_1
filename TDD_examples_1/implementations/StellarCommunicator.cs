using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_examples_1.implementations
{
    public class StellarCommunicator
    {
        private const int NumberOfTries = 3;
        private ShortRangeCom srCom;
        private LongRangeCom lrCom;
        private const long ShortRangeMax = 25000L; // maximum range of S.R.Com.

        public bool SendMessage(double distance, string spaceAddress, string message)
        {
            // Figure out what communicator to use and send the message
            // Messages may become lost in space so we should retry sending up to 3 times
            throw new NotImplementedException();
        }
    }
    // Short range communication is a lot more efficient, but only up to maximum range
    public class ShortRangeCom
    {
        public bool SendMessage(string spaceAddress, string message)
        {
            throw new NotImplementedException();
        }
    }
    // Long range is a lot more expensive than short range and should be avoided unless absolutely neccessary
    public class LongRangeCom
    {
        public void SendMessage(string spaceAddress, string message)
        {
            throw new NotImplementedException();
        }
    }
}
