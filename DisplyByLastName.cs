﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace VisualLinkedList
{
    class DisplyByLastName
    {
        private LinkedList.Node head;

        public DisplyByLastName(LinkedList.Node h)
        {
            head = h; 
        }

        public ArrayList displayTheListNames()
        {
            LinkedList.Node current = head;
            ArrayList list = new ArrayList();

            if (null == head)
                list.Add("There are no names on the list");
            else
            {
                while (null != current)
                {
                    list.Add(current.getFirstName() + " " + current.getLastName());
                    current = current.nextLastName;
                }
            }

            return list;
        }//end displayTheListNames()
    }
}
