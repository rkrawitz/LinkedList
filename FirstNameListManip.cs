using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class FirstNameListManip
    {
        public Node headFirstName;
        private String firstName;
        private String lastName;

        public FirstNameListManip()
        {
            headFirstName = null;
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

                    return firstName + " added";
                case '2'://locate a node 
                    if (null == headFirstName)
                        return "empty list, nothing to find";
                    foundNode = findNode(firstName);
                    if (null == foundNode)
                        return  firstName + " is not on the list";
                    else
                        return "found the node that contains " + firstName + " and its name is " + foundNode.getFirstName();
                case '3'://remove a node
                    if (null == headFirstName)
                        return "empty list";
                    foundNode = findNode(firstName);
                    if (null == foundNode)
                        return firstName + " is not on the list";
                    else
                    {
                        removeNode(foundNode);
                        return firstName + " has been removed";
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

            if (null == headFirstName)
                headFirstName = temp;
            else
                insertNode(temp);
        }//end addNode()

        private Node findNode(String findItem)
        {
            Node current = headFirstName;

            while (current.getFirstName().CompareTo(findItem) != 0)//names don't match
            {
                if (null == current.nextFirstName)//reached the end of the list
                    return null;//findItem is not in the list

                current = current.nextFirstName;//found the match
            }

            return current;
        }//end findNode()

        private String chooseNode(String message)
        {
            if (null == headFirstName)
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
            Node current = headFirstName;

            Node ip = findInsertionPoint(temp);

            //new node goes before head
            if (null == ip)
            {
                temp.nextFirstName = headFirstName;
                headFirstName.prevFirstName = temp;
                headFirstName = temp;
                return;
            }

            //new node goes in the middle or after the end
            temp.prevFirstName = ip;
            temp.nextFirstName = ip.nextFirstName;
            if (ip.nextFirstName != null)//general case where temp does not go after last node
                ip.nextFirstName.prevFirstName = temp;
            ip.nextFirstName = temp;
            return;
        }//end insertNode()

        private Node findInsertionPoint(Node temp)
        {
            //define Insertion Point as the node after which temp should be inserted
            Node current = headFirstName;

            if (headFirstName.getFirstName().CompareTo(temp.getFirstName()) > 0)
                return null;

            while (current.getFirstName().CompareTo(temp.getFirstName()) < 0)
            {
                if (null == current.nextFirstName)
                    return current;
                else
                    current = current.nextFirstName;
            }

            return current.prevFirstName;
        }//end findInsertionPoint()

        private void removeNode(Node foundNode)
        {
            if (foundNode == headFirstName)
            {
                if (null == headFirstName.nextFirstName)
                {
                    headFirstName = null;
                }
                else
                {
                    headFirstName.nextFirstName.prevFirstName = null;
                    headFirstName = headFirstName.nextFirstName;
                }
            }
            else if (null == foundNode.nextFirstName)//foundNode is last node
            {
                foundNode.prevFirstName.nextFirstName = null;
            }
            else //foundNode is in the middle
            {
                foundNode.prevFirstName.nextFirstName = foundNode.nextFirstName;
                foundNode.nextFirstName.prevFirstName = foundNode.prevFirstName;
            }

            foundNode = null;
        }//end removeNode()

        private Node findLastNode()
        {
            Node current = headFirstName;

            do
            {
                if (current.nextFirstName == null)
                    return current;

                current = current.nextFirstName;
            } while (true);
        }//end findLastNode()

        public String showAllNodes()
        {
            String nodeList = "";
            Node current = headFirstName;

            if (null == headFirstName)
                return "there are no nodes on this list";

            while (current != null)
            {
                nodeList += current.getFirstName() + "\n";

                current = current.nextFirstName;
            }

            return nodeList;
        }//end showAllNodes
    }
}
