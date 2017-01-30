using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_examples_1.implementations
{
    public class StellarCommunicator
    {
        public const int NumberOfTries = 3;
        private ISpaceRangeCom srCom;
        private ISpaceRangeCom lrCom;
        public const long ShortRangeMax = 25000L; // maximum range of S.R.Com.

        public void ChooseRangeType(ISpaceRangeCom shortRange,
            ISpaceRangeCom longRange)
        {
            srCom = shortRange;
            lrCom = longRange;
        }

        public bool SendMessage(double distance, string spaceAddress,
            string message)
        {
            // Figure out what communicator to use and send the message
            // Messages may become lost in space so we should
            // retry sending up to 3 times
            bool badDistance = double.IsInfinity(distance)
                || double.IsNaN(distance) || distance < 0;
            if (badDistance || string.IsNullOrEmpty(spaceAddress) ||
                string.IsNullOrEmpty(message))
                throw new Exception();
            bool result = false;
            int counter = 0;
            while (!result && counter < NumberOfTries)
            {
                if (distance <= ShortRangeMax)
                    result = srCom.SendMessage(spaceAddress, message);
                else
                    result = lrCom.SendMessage(spaceAddress, message);
                counter++;
            }
            return result;
        }

        /*public int Add(int x, int y)
        {
            return x + y;
        }*/
    }
    // Short range communication is a lot more efficient, but only up to maximum range
    public class ShortRangeCom : ISpaceRangeCom
    {
        public bool SendMessage(string spaceAddress, string message)
        {
            throw new NotImplementedException();
        }
    }
    // Long range is a lot more expensive than short range and should be avoided unless absolutely neccessary
    public class LongRangeCom : ISpaceRangeCom
    {
        public bool SendMessage(string spaceAddress, string message)
        {
            throw new NotImplementedException();
        }
    }
    public interface ISpaceRangeCom
    {
        bool SendMessage(string spaceAddress, string message);
    }
}
