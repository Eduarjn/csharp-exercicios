using System;
using System.IO;

// EXCEEDING REQUIREMENTS:
// To exceed the core requirements, I added basic error handling in the Journal.cs file 
// to check if a file exists before trying to load it (using File.Exists). 
// I also used a custom separator ("~~") instead of a comma when saving to the text file 
// to prevent data corruption if the user types a comma in their journal entry.
// Added filename validation in the menu so the program does not crash if the user
// presses Enter without typing a name.

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        string choice = "";

        Console.WriteLine("Welcome to the Journal Program!");

        while (choice != "5")
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            
            choice = Console.ReadLine() ?? "";

            if (choice == "1")
            {
                string prompt = promptGen.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine() ?? "";

                Entry newEntry = new Entry();
                newEntry._date = DateTime.Now.ToShortDateString();
                newEntry._promptText = prompt;
                newEntry._entryText = response;

                myJournal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                myJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? (e.g., myJournal.txt): ");
                string file = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(file))
                {
                    Console.WriteLine("Filename cannot be empty.");
                }
                else
                {
                    myJournal.LoadFromFile(file);
                }
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? (e.g., myJournal.txt): ");
                string file = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(file))
                {
                    Console.WriteLine("Filename cannot be empty.");
                }
                else
                {
                    myJournal.SaveToFile(file);
                }
            }
            else if (choice != "5")
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }
    }
}