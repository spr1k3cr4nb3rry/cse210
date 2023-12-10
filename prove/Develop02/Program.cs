using System;
using System.IO;

class Program
{
    enum MenuOption {
        Write = 1, 
        Display,
        Load,
        Save,
        Quit
    }

    static void Main(string[] args)
    {
        int[] validNumbers = { 1, 2, 3, 4, 5 };
        MenuOption choice = 0;
        
        Journal journal = new Journal();
        Prompt journalPrompt = new Prompt();

        while (choice != MenuOption.Quit)
        {
            choice = (MenuOption) DisplayMenu();

            switch (choice)
            {
                case MenuOption.Write: // Write.
                    string dateInfo = GetDateTime();
                    string prompt = journalPrompt.GetPrompt();

                    Entry entry = new Entry 
                    {
                        _dateTime = dateInfo,
                        _prompt = prompt
                    };

                    Console.WriteLine($"{prompt}");
                    Console.Write(">>> ");
                    string userEntry = Console.ReadLine();
                    entry._entryText = userEntry;

                    journal._journal.Add(entry);
                    break;

                case MenuOption.Display: // Display.
                    journal.Display();
                    break;

                case MenuOption.Load: // Load
                    journal.LoadFile();
                    break;

                case MenuOption.Save: // Save.
                    journal.CheckFile();
                    break;

                case MenuOption.Quit: // Quit.
                    break;

                default: // Invalid option (choice != 1, 2, 3, 4, 5).
                    Console.WriteLine("Invalid option. ");
                    break;

            }
        }
    }

    static int DisplayMenu()
    {
        string menu = @"Please select one of the following choices:
        1. Write
        2. Display
        3. Load
        4. Save
        5. Quit
        What would you like to do? ";

        Console.Write(menu);

        string input = Console.ReadLine();
        if (Enum.TryParse(input, out MenuOption choice))
        {
            return (int) choice;
        }
        else
        {
            Console.WriteLine("Invalid option. ");
            return 0;
        }
    }

    static string GetDateTime()
    {
        DateTime now = DateTime.UtcNow;
        string currentDateTime = now.ToString("MM/dd/yyyy");
        return currentDateTime;
    }
}