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
                    Console.WriteLine();
                    _journal.AddNewEntry();
                    break;
                case "2":
                    Console.WriteLine();
                    _journal.DisplayAllEntries();
                    break;
                case "3":
                    Console.WriteLine();
                    Load();
                    break;
                case "4":
                    Console.WriteLine();
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
        Console.Write("Which file would you like to load? ");
        string filename = Console.ReadLine();
        _journal.ReadFromFile(filename);
    }

    public void Save()
    {
        Console.Write("Which file would you like to save your data to? ");
        string filename = Console.ReadLine();
        _journal.WriteToFile(filename);
    }
}