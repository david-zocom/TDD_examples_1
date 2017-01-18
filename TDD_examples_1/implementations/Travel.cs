using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_examples_1.implementations
{
    public class Travel : ITravel
    {
        private string destination = null;
        private string origin = null;

        public bool BookTrip(string destination)
        {
            if (destination == null || destination == "")
                return false;  // illegal value fail
            else if (destination == origin)
                return false;  // disallowed value fail

            this.destination = destination;
            return true;
        }
        public bool SetOrigin(string origin)
        {
            if (origin == null || origin == "")
                return false;
            else if (origin == destination)
                return false;

            this.origin = origin;
            return true;
        }
        public string GetPosition()
        {
            if (origin == null || origin == "")
                throw new Exception();
            return origin;
        }

        public bool GoOnTrip()
        {
            //string.IsNullOrEmpty
            if (origin == null || destination == null || origin == "" || destination == "")
                throw new Exception();
            if (origin == destination)
                return false;
            origin = destination;
            destination = null;
            return true;
        }


    }
}
