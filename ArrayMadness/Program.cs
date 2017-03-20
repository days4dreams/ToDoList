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

            string file = "C:\\MyFile.txt";
            // a single backslash in a special character. Using two to indicate a single \ for file path
            string title = "test";
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
                Console.WriteLine("\nOK!");
                Console.WriteLine("\nHere is how your To Do List looks:\n");
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
                        File.WriteAllText(file, stringValues);
                    //converts list to string, pushes to text file
                }
                
            }

            string content = File.ReadAllText(file);
            Console.WriteLine(content);
            // looks for the file in location string file and prints all of the text to the console

            // add in logic for saving a copy
            string targetPath = @"C:\Users\";
            //Console.WriteLine("\nThis looks like important info! Let's make a backup.");
            //Console.WriteLine("Where would you like to save a copy of your To Do List? Please include the full path.");
            //Console.WriteLine("EG. C:\\Users");
            //string targetPathUser = string.Empty;
            //targetPathUser = Console.ReadLine();
            //string newPlace = "";
            //newPlace = "@" + targetPathUser;


            // Use Path class to manipulate file and directory paths.
            string sourceFile = @"C:\MyFile.txt";
            string destFile = Path.Combine(targetPath, title);

            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            File.Copy(sourceFile, destFile);

            // access file info
            FileInfo ToDoListInfo = new FileInfo("C:\\MyFile.txt");
            // we can call the class FileInfo because it existing the .Net framework library (its not a complex object)
            // we create a new object and tell it to point to the path of MyToDoList.txt

            long fileLength = ToDoListInfo.Length;
            DateTime fileCreated = ToDoListInfo.CreationTime;
            // capture information for the attriibutes of our To Do List

            // Console.WriteLine("\nYour To Do List is " + fileLength + " characters in length"); this is not working
            Console.WriteLine("Your To Do List was created at " + fileCreated);
            // would be nice to add an item count / line count so user knows how my items are in to do list

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

