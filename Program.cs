using System;

namespace CSharpTest
{
    class Program
    {
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
                System.Console.WriteLine(args[0]);

                int counter = 0;  
                string line; 

                System.IO.StreamReader file =
                new System.IO.StreamReader(args[0]);  
                while((line = file.ReadLine()) != null)  
                {  
                    System.Console.WriteLine(line);  
                    counter++;  
                }  
                
                file.Close();  
                System.Console.WriteLine("There were {0} lines.", counter);  
            }

            

            return 0;
        }
    }
}
