using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Journal
{
    public List<Entry> _journal = new List<Entry>();
    private string _filename;

    public Journal() { }

    public void Display()
    {
        foreach (Entry entry in _journal) 
        {
            entry.Display();
            Console.WriteLine(Environment.NewLine);
        }
    }

    public void CheckFile()
    {
        Console.Write("Enter file name: ");
        string input = Console.ReadLine();
        _filename = Path.Combine(Environment.CurrentDirectory, input + ".txt");

        if (!File.Exists(_filename))
        {
            Console.WriteLine($"Filename {_filename} could not be found! Creating new file...");
            CreateFile(_filename);
        }
        else
        {
            Console.WriteLine($"Filename {_filename} found.");
            AppendEntries();
            Console.WriteLine($"Entries saved to {_filename}.");
        }
    }

    private void CreateFile(string _filename)
    {
        File.WriteAllText(_filename, string.Empty);
        Console.WriteLine($"{_filename} has been created!");
        SaveFile();
        Console.WriteLine($"Entries saved to {_filename}!");
    }

    private void SaveFile()
    {
        File.WriteAllText(_filename, string.Join(Environment.NewLine, _journal.Select(entry =>
            $"{entry._dateTime}, {entry._prompt}; {entry._entryText}")));
    }

    public void AppendEntries()
    {
        File.AppendAllText(_filename, string.Join(Environment.NewLine, _journal.Select(entry =>
            $"{entry._dateTime}; {entry._prompt}; {entry._entryText}")));
    }

     public void LoadFile()
    {
        Console.Write("Enter file name: ");
        string input = Console.ReadLine();
        _filename = Path.Combine(Environment.CurrentDirectory, input + ".txt");

        if (File.Exists(_filename))
        {
            List<string> text = File.ReadAllLines(_filename).Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();
            foreach (string line in text)
            {
                string[] entries = line.Split("; ");

                Entry entry = new Entry
                {
                    _dateTime = entries[0],
                    _prompt = entries[1],
                    _entryText = entries[2]
                };

                _journal.Add(entry);
            }
        }
    }
}