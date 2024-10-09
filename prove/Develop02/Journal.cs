using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

public class Journal
{
    private string[] _prompts = 
    {
        "Are you taking enough risks in your life? Would you like to change your relationship to risk? If so, how?",
        "At what point in your life have you had the highest self-esteem?",
        "Consider and reflect on what might be your 'favorite failure.'",
        "Find two unrelated objects near you and think of a clever way they might be used together.",
        "How can you reframe one of your biggest regrets in life?",
        "How did you bond with one of the best friends you’ve ever had?",
        "How did your parents or caregivers try to influence or control your behavior when you were growing up?"
    };

    private List<JournalEntry> _entries = new();

    public void AddNewEntry()
    {
        Random random = new();
        string prompt = _prompts[random.Next(_prompts.Length)];
        Console.WriteLine(prompt);
        string response = Console.ReadLine();
        _entries.Add(new JournalEntry(prompt, response));
    }

    public void DisplayAllEntries()
    {
        foreach (JournalEntry entry in _entries)
        {
            entry.DisplayEntry();
        }
    }

    public void ReadFromFile(string filename)
    {
        _entries.Clear();
        using (StreamReader file = new(filename))
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string prompt = line;
                string response = file.ReadLine();
                DateTime date = DateTime.Parse(file.ReadLine());
                _entries.Add(new JournalEntry(prompt, response) { Date = date });
            }
        }
    }

    public void WriteToFile(string filename)
    {
        using (StreamWriter file = new(filename))
        {
            foreach (JournalEntry entry in _entries)
            {
                file.WriteLine(entry.Prompt);
                file.WriteLine(entry.Response);
                file.WriteLine(entry.Date);
            }
        }
    }
}
