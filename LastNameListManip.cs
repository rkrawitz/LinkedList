using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class LastNameListManip
    {
        public Node headLastName;
        private String firstName;
        private String lastName;

        public LastNameListManip()
        {
            headLastName = null;
        }

        public String manipTheList(char choice, String firstn, String lastn)
        {
            firstName = firstn;
            lastName = lastn;

            Node foundNode;

            switch (choice)
            {
                case '0':
                    System.Environment.Exit(-1);
                    break;
                case '1'://add a node
                    addNode();

                    return lastName + " added";
                case '2'://locate a node 
                    if (null == headLastName)
                        return "empty list, nothing to find";
                    foundNode = findNode(lastName);
                    if (null == foundNode)
                        return  lastName + " is not on the list";
                    else
                        return "found the node that contains " + lastName + " and its name is " + foundNode.getLastName();
                case '3'://remove a node
                    if (null == headLastName)
                        return "empty list";
                    foundNode = findNode(lastName);
                    if (null == foundNode)
                        return lastName + " is not on the list";
                    else
                    {
                        removeNode(foundNode);
                        return lastName + " has been removed";
                    }
                case '4'://display all nodes
                    return showAllNodes();
                default:
                    break;
            }

            return null;

        }//end ListManip()

        private char menu()
        {
            String choice;

            Console.WriteLine("0 = exit\n1 = addNode\n2 = find which node contains a particular name\n3 = remove a node\n4 = show all nodes");

            choice = Console.ReadLine();

            return Convert.ToChar(choice);
        }//end menu()

        public void addNode()
        {
            Node temp;

            temp = new Node();
            temp = initializeNode(temp);

            if (null == headLastName)
                headLastName = temp;
            else
                insertNode(temp);
        }//end addNode()

        private Node findNode(String findItem)
        {
            Node current = headLastName;

            while (current.getLastName().CompareTo(findItem) != 0)//names don't match
            {
                if (null == current.nextLastName)//reached the end of the list
                    return null;//findItem is not in the list

                current = current.nextLastName;//found the match
            }

            return current;
        }//end findNode()

        private String chooseNode(String message)
        {
            if (null == headLastName)
                return null;

            Console.WriteLine("\n" + message);
            showAllNodes();
            Console.Write("> ");
            return Console.ReadLine();
        }//end chooseNode

        private Node initializeNode(Node temp)
        {
            temp.setFirstName(firstName);
            temp.setLastName(lastName);
            return temp;
        }//end initializeNode()

        private void insertNode(Node temp)
        {
            Node current = headLastName;

            Node ip = findInsertionPoint(temp);

            //new node goes before lastNameHead
            if (null == ip)
            {
                temp.nextLastName = headLastName;
                headLastName.prevLastName = temp;
                headLastName = temp;
                return;
            }

            //new node goes in the middle or after the end
            temp.prevLastName = ip;
            temp.nextLastName = ip.nextLastName;
            if (ip.nextLastName != null)//general case where temp does not go after last node
                ip.nextLastName.prevLastName = temp;
            ip.nextLastName = temp;
            return;
        }//end insertNode()

        private Node findInsertionPoint(Node temp)
        {
            //define Insertion Point as the node after which temp should be inserted
            Node current = headLastName;

            if (headLastName.getLastName().CompareTo(temp.getLastName()) > 0)
                return null;

            while (current.getLastName().CompareTo(temp.getLastName()) < 0)
            {
                if (null == current.nextLastName)
                    return current;
                else
                    current = current.nextLastName;
            }

            return current.prevLastName;
        }//end findInsertionPoint()

        private void removeNode(Node foundNode)
        {
            if (foundNode == headLastName)
            {
                if (null == headLastName.nextLastName)
                {
                    headLastName = null;
                }
                else
                {
                    headLastName.nextLastName.prevLastName = null;
                    headLastName = headLastName.nextLastName;
                }
            }
            else if (null == foundNode.nextLastName)//foundNode is last node
            {
                foundNode.prevLastName.nextLastName = null;
            }
            else //foundNode is in the middle
            {
                foundNode.prevLastName.nextLastName = foundNode.nextLastName;
                foundNode.nextLastName.prevLastName = foundNode.prevLastName;
            }

            foundNode = null;
        }//end removeNode()

        private Node findLastNode()
        {
            Node current = headLastName;

            do
            {
                if (current.nextLastName == null)
                    return current;

                current = current.nextLastName;
            } while (true);
        }//end findLastNode()

        public String showAllNodes()
        {
            String nodeList = "";
            Node current = headLastName;

            if (null == headLastName)
                return "there are no nodes on this list";

            while (current != null)
            {
                nodeList += current.getLastName() + "\n";

                current = current.nextLastName;
            }

            return nodeList;
        }//end showAllNodes
    }
}
