using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Menu
{
    private List<Scripture> _scriptures = new();

    public void DisplayMenu()
    {
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        while (true)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Memorize");
            Console.WriteLine("2. Add Scripture");
            Console.WriteLine("3. View Scriptures");
            Console.WriteLine("4. Load Scriptures from File");
            Console.WriteLine("5. Save Scriptures to File");
            Console.WriteLine("6. Quit");
            Console.Write("\nWhat would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Memorize();
                    break;
                case "2":
                    AddScripture();
                    break;
                case "3":
                    ViewScriptures();
                    break;
                case "4":
                    Load();
                    break;
                case "5":
                    Save();
                    break;
                case "6":
                    Console.WriteLine("See you again soon!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again!");
                    break;
            }
        }
    }

    void Memorize()
    {
        if (_scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures available to memorize! Please load or add scriptures before beginning.");
            return;
        }

        Console.WriteLine("Which scripture would you like to memorize? ");
        for (int i = 0; i < _scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_scriptures[i].ScriptureReference}");
        }

        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= _scriptures.Count)
        {
            Scripture scripture = _scriptures[choice - 1];
            while (!scripture.AllWordsHidden())
            {
                Console.Clear();
                scripture.Display();
                Console.WriteLine("\nPress ENTER to hide more words, or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                    break;

                scripture.HideRandomWords(3);
            }

            Console.Clear();
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    private static (int, int) StringToIntVerses(string strVerse)
    {
        string[] verses = strVerse.Split('-');
        int startVerse = int.Parse(verses[0]);
        int endVerse = (verses.Length > 1) ? int.Parse(verses[1]) : startVerse;
        return (startVerse, endVerse);
    }

    void AddScripture()
    {
        Console.Write("What is the book of the scripture you would like to add? ");
        string book = Console.ReadLine();

        Console.Write("What is the chapter? ");
        int chapter = int.Parse(Console.ReadLine());

        Console.Write("What verse(s) would you like to add? If multiple, separate them with a hyphen (e.g., 5-6): ");
        var verses = StringToIntVerses(Console.ReadLine());

        Console.Write("Please copy/paste the text of the verse(s) you would like to memorize: ");
        string text = Console.ReadLine();

        ScriptureReference scriptureReference;
        if (verses.Item1 == verses.Item2)
        {
            scriptureReference = new(book, chapter, verses.Item1);
            Console.WriteLine($"{book} {chapter}:{verses.Item1} added successfully.");
        } 
        else 
        {
            scriptureReference = new(book, chapter, verses.Item1, verses.Item2);
            Console.WriteLine($"{book} {chapter}:{verses.Item1}-{verses.Item2} added successfully.");
        }
        _scriptures.Add(new Scripture(scriptureReference, text));
    }

    void ViewScriptures()
    {
        if (_scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures added yet!");
            return;
        }

        foreach (Scripture scripture in _scriptures)
        {
            scripture.Display();
            Console.WriteLine();
        }
    }

    public void Load()
    {
        Console.Write("Enter the filename to load scriptures from: ");
        string filename = Console.ReadLine();

        try
        {
            using StreamReader file = new(filename);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string book = line;
                int chapter = int.Parse(file.ReadLine());
                var verses = StringToIntVerses(file.ReadLine());
                string text = file.ReadLine();

                ScriptureReference scriptureReference = (verses.Item1 == verses.Item2) ?
                    new ScriptureReference(book, chapter, verses.Item1) :
                    new ScriptureReference(book, chapter, verses.Item1, verses.Item2);

                _scriptures.Add(new Scripture(scriptureReference, text));
            }
            Console.WriteLine($"Scriptures successfully loaded from {filename}.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading file: {e.Message}");
        }
    }

    public void Save()
    {
        Console.Write("Enter the filename to save scriptures to: ");
        string filename = Console.ReadLine();

        try
        {
            using StreamWriter file = new(filename);
            foreach (Scripture scripture in _scriptures)
            {
                file.WriteLine(scripture.ScriptureReference.Book);
                file.WriteLine(scripture.ScriptureReference.Chapter);
                file.WriteLine(scripture.ScriptureReference.StartVerse == scripture.ScriptureReference.EndVerse
                    ? scripture.ScriptureReference.StartVerse.ToString()
                    : $"{scripture.ScriptureReference.StartVerse}-{scripture.ScriptureReference.EndVerse}");
                file.WriteLine(scripture.Text);
            }

            Console.WriteLine($"Scriptures successfully saved to {filename}.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving file: {e.Message}");
        }
    }
}
