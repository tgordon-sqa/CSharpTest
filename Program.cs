﻿using System;

namespace CSharpTest
{
    class LinkedListNode
    {
        public int Data;
        public LinkedListNode Next;

        public LinkedListNode(int data) {
            Data = data;
        }
    } // LinkedListNode

    class LinkedList
    {
        public LinkedListNode First;
        public LinkedListNode Last;
        
        // Empty constructor
        public LinkedList() { }

        public void appendNode(int data) {
            // Create node
            LinkedListNode newNode = new LinkedListNode(data);

            // If this is the first node, set First and Last
            if (First is null && Last is null)
            {
                First = newNode;
                Last = newNode;
            }
            else 
            {
                // Update Next ref of previous last node
                Last.Next = newNode;

                // Update Last 
                Last = newNode;
            }
        } // appendNode

        public void deleteFirstNodeWithValue(int deleteValue) {
            if (First is null && Last is null)
                System.Console.WriteLine($"Cannot delete {deleteValue} from an empty list.");

            else
            {
                LinkedListNode currentNode = First;
                LinkedListNode prevNode = null;

                while (currentNode is not null) 
                {
                    if (currentNode.Data == deleteValue)
                    {
                        // If there is a previous Node:
                        if (prevNode is not null)
                            // Set previous Node's next to the Node-to-be-deleted's next.
                            prevNode.Next = currentNode.Next;
                        
                        // Else the node being deleted is the first Node:
                        else
                        {
                            // If the list only has 1 Node, then clear Last too.
                            if (First == Last)
                                Last = null;

                            First = currentNode.Next;
                            // If the list has length 1, currentNode.Next will be null, which is desired in that case.
                        } // else

                        // Only delete the first instance of the value.
                        break;
                    } // if

                    else
                    {
                        // Iterate to the next node
                        prevNode = currentNode;
                        currentNode = currentNode.Next;

                        // If the value was not present in the list:
                        if (currentNode is null)
                            System.Console.WriteLine($"Cannot delete {deleteValue} because it does not currently exist in the list.");
                    } // else
                } // while
            } // else
        } // deleteFirstNodeWithValue

        public void printList() {
            if (First is null && Last is null)
                System.Console.WriteLine("List is empty.");
            else 
            {
                int currentNodeNum = 1;

                LinkedListNode currentNode = First;

                while (currentNode is not null) 
                {
                    System.Console.WriteLine($"Node{currentNodeNum}:{currentNode.Data}");

                    // Iterate to the next node
                    currentNode = currentNode.Next;
                    currentNodeNum += 1;
                } // while
            } // else
        } // printList
    } // LinkedList


    class Program
    { 
        // This method is called when an invalid input format is detected.
        static void inputFormatError(string line) {
            System.Console.WriteLine($"Invalid input line: {line}");
        }

        static int Main(string[] args)
        {
            // Check for an input file argument
            if (args.Length != 1)
            {
                System.Console.WriteLine("Please enter exactly one input file.");
                return 1;
            } 
            else 
            {
                string line; 

                System.IO.StreamReader inputFile =
                new System.IO.StreamReader(args[0]);  

                // Create list
                LinkedList linkedList = new LinkedList();


                // Assign the next line of the file to line. If it isn't null, then:
                while((line = inputFile.ReadLine()) != null)  
                {  
                    try
                    {
                        string[] operationAndValue = line.Split(":");
                        if (operationAndValue.Length != 2)
                        {
                            inputFormatError(line);
                            return 1;
                        }

                        string operation = operationAndValue[0];
                        string strValue = operationAndValue[1];

                        int value = Int32.Parse(strValue);

                        if (operation == "i")
                            linkedList.appendNode(value);

                        else if (operation == "d")
                            linkedList.deleteFirstNodeWithValue(value);

                        else 
                        {
                            inputFormatError(line);
                            return 1;
                        }
                    } // try

                    catch (FormatException)
                    {
                        inputFormatError(line);
                        return 1;
                    }
                } // while

                linkedList.printList();

                inputFile.Close();  

                return 0;
            } // else
        } // Main
    } // Program
} // CSharpTest