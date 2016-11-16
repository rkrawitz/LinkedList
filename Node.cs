using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Node
    {
        public Node nextFirstName;
        public Node prevFirstName;
        public Node nextLastName;
        public Node prevLastName;
        private String firstName;
        private String lastName;

        public Node()
        {
            nextFirstName = null;
            prevFirstName = null;
            firstName = null;
        }

        public void setFirstName(String s)
        {
            firstName = s;
        }

        public String getFirstName()
        {
            return firstName;
        }

        public void setLastName(String s)
        {
            lastName = s;
        }

        public String getLastName()
        {
            return lastName;
        }
    }
}
