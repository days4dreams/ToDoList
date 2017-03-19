using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// declared the System.IO in order to use 'File' 

namespace ArrayMadness
{
    class Program
    {
        static void Main(string[] args)
        {

            string file = "C:\\MyToDoList.txt";
            // a single backslash in a special character. Using two to indicate a single \ for file path
            string title = "To Do List\n";
            File.WriteAllText(file, title);
            // creates a text file in the location of string file and puts the string contents in it

            List<string> list = new List<string>();
            list.Add("Buy milk and bread");
            list.Add("Wash the car");
            list.Add("Call the bank");

            Console.WriteLine("Welcome");
            List<string> yesAnswers = new List<string>() { "yes", "true", "ok" };  //everything is lowercase

            string newItem = string.Empty;
            bool decision = false;
            Console.WriteLine("Would you like to add something to the list?");
                newItem = Console.ReadLine();
                decision = yesAnswers.Contains(newItem.ToLower());  //now use ToLower so that I convert the value to be all lower case. I don't have to worry about uppercase now. 
            if (decision == false)// whilst the anser is a no, do this
            {
                Console.WriteLine("Suit yourself!\n");
                Console.WriteLine("\nHere is how your todo list looks:\n");
                foreach (string entry in list)
                {
                    Console.WriteLine(entry);
                }
            }

            else {
                Console.WriteLine("Great, lets add a new task"); //whilst the answer is a yes, do (do) this, or if not do (else), whilst (while)
                Console.WriteLine("Enter each new task on a new line.\nType 'done' to add them to your list.\n");
                string input = "";
                while (input != "done")
                    {
                        input = Console.ReadLine();
                        list.Add(input);
                    }

                    Console.WriteLine("\nHere is how your To Do list looks:\n");
                    string[] array = list.ToArray();
                    foreach (string stringValues in array)
                    {
                        Console.WriteLine(stringValues);
                    }
            }

            string[] array2 = list.ToArray();
            foreach (string stringValues in array2)
            File.WriteAllText(file, stringValues);
            //converts list to string, pushes to text file

            string content = File.ReadAllText(file);
            Console.WriteLine(content);
            // looks for the file in location string file and prints all of the text to the console

            // add in logic for saving a copy


            // access file info
            FileInfo ToDoListInfo = new FileInfo("C:\\MyToDoList.txt");
            // we can call the class FileInfo because it existing the .Net framework library (its not a complex object)
            // we create a new object and tell it to point to the path of MyToDoList.txt

            long fileLength = ToDoListInfo.Length;
            DateTime fileCreated = ToDoListInfo.CreationTime;
            // capture information for the attriibutes of our To Do List

            Console.WriteLine("Your To Do List is " + fileLength + " characters in length");
            Console.WriteLine("Your To Do List was created at " + fileCreated);
            // would be nice to add an item count / line count so user knows how my items are in to do list

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
