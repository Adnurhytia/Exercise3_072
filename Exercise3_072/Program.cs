﻿using System;
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks;

namespace Exercise_Linked_List_A
{
    class Node
    {
        /*creates Nodes for the circular nexted list*/
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node LAST;
        public CircularList()
        {
            LAST = null;
        }
        
        //Menambahkan Node
        public void addNode()
        {
            int rollNo;
            string nm;

            Console.Write("\nEnter the roll number of the student: ");
            rollNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nEnter the name of student: ");
            nm = Console.ReadLine();

            //Membuat objek baru dengan nama newnode
            Node newNode = new Node();

            //Untuk menyimpan list node
            newNode.rollNumber = rollNo;
            newNode.name = nm;

            //If the list empty
            if (ListEmpty())
            {
                newNode.next = newNode;
                LAST = newNode;
            }
            //Menambahkan node
            else if (rollNo < LAST.next.rollNumber)
            {
                newNode.next = LAST.next;
                LAST.next = newNode;
            }
        }

        public bool Search(int rollNo, ref Node previous, ref Node current)
        /*Searches for the specified node*/
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true);
                /*returns true if the node is found*/
            }
            if (rollNo == LAST.rollNumber) /*If the node is present at the end*/
                return true;
            else
                return (false); /*returns false if the node is not found*/
        }
        public bool ListEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public void traverse() /*Traverse all the nodes of the list*/
        {
            if (ListEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the list are:\n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != null)
                {
                    Console.Write(LAST.rollNumber + "  " + currentNode.name + "\n");
                }
            }

        }
        public void firstNode()
        {
            if (ListEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first record in the list is:\n\n " + LAST.next.rollNumber + "  " + LAST.next.name);
        }
        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. View all the records in the list");
                    Console.WriteLine("2. Search for a record in the list");
                    Console.WriteLine("3. Display the first record in the list");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nEnter your choice (1-4) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.traverse();
                            }
                            break;
                        case '2':
                            {
                                if (obj.ListEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the students whose recrd is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + curr.rollNumber);
                                    Console.WriteLine("\nName: " + curr.name);

                                }
                            }
                            break;

                        case '3':
                            {
                                obj.firstNode();
                            }
                            break ;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
            

    }
}