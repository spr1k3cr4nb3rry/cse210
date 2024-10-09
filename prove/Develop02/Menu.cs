using System;

class Menu
{
    private Journal _journal;

    public Menu(Journal journal)
    {
        _journal = journal;
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Welcome to the Journal Program!");
        while (true)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _journal.AddNewEntry();
                    break;
                case "2":
                    _journal.DisplayAllEntries();
                    break;
                case "3":
                    Load();
                    break;
                case "4":
                    Save();
                    break;
                case "5":
                    Console.WriteLine("See you again soon!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void Load()
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        _journal.ReadFromFile(filename);
    }

    public void Save()
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        _journal.WriteToFile(filename);
    }
}