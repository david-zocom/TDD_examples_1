using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_examples_1
{
    public interface ITravel
    {
        /* Attempts to book a trip (buy a ticket) to the destination.
         * The parameter must be a non-empty string that is not equal
         * to the origin position. Returns true if successful.
         */
        bool BookTrip(string destination);

        /* Attempts to define the user's current location. The
         * parameter must be a non-empty string that is not equal to
         * the destination position. Returns true if successful.
         */
        bool SetOrigin(string origin);

        /* Attempts to travel from an origin to a destination.
         * Requires both origin and destination to be set. Should
         * throw an exception if either origin or destination has not
         * been set. Returns false if origin and destination have been
         * set, but have incorrect values; otherwise returns true.
         */
        bool GoOnTrip();

        /* Returns the current position of the user. Before a trip
         * has been made, the position is equal to origin. After a
         * trip it is equal to destination. May throw an exception.
         */
        string GetPosition();
    }

    public class NoOriginOrDestinationException : Exception
    {
        public NoOriginOrDestinationException(string message) : base(message) { }
    }
}
