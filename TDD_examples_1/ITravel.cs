using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_examples_1
{
    public interface ITravel
    {
        bool BookTrip(string destination);
        bool SetOrigin(string origin);
        bool GoOnTrip();
        string GetPosition();
    }

    public class NoOriginOrDestinationException : Exception
    {
        public NoOriginOrDestinationException(string message) : base(message) { }
    }
}
