using System;

namespace CSharpTest
{

    class LinkedListNode
    {
        public int Data;
        public LinkedListNode Next;


        public LinkedListNode(int data) {
            Data = data;
        }

        public void setNext(ref LinkedListNode next) {
            Next = next;
        }

    }

    class LinkedList
    {
        public LinkedListNode First;
        public LinkedListNode Last;
        
        // Empty constructor
        public LinkedList() { }

        public void addNode(int data) {
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


        }

        public void deleteNode(int value) {
            System.Console.WriteLine($"TODO: Delete node with value {value}");

        }

        public void printList() {
            LinkedListNode currentNode = First;


        }

    }


    class Program
    { 

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


                // Assign the next line of the file to line. If it isn't null, then...
                while((line = inputFile.ReadLine()) != null)  
                {  
                    string[] operationAndValue = line.Split(":");
                    string operation = operationAndValue[0];
                    string strValue = operationAndValue[1];

                    try
                    {
                        int value = Int32.Parse(strValue);

                        if (operation == "i")
                            linkedList.addNode(value);

                        else if (operation == "d")
                            linkedList.deleteNode(value);

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
            }
        }
    }
}
