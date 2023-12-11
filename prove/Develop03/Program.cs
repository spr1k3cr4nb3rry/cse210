using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var scripture = new Scripture("Proverbs", 3, 5, 6, "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths.");

        do
        {
            Console.Clear();
            scripture.DisplayScripture();
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish: ");

            string input = Console.ReadLine().ToLower();
            if (input == "quit")
                break;

            if (!scripture.HideWord())
            {
                break;
            }
        } while (true);
    }
}