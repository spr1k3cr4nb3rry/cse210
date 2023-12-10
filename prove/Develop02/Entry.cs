using System;
using System.Text.RegularExpressions;

public class Entry
{
    public string _dateTime { get; set; } = "";
    public string _prompt { get; set; } = "";
    public string _entryText { get; set; } = "";

    public Entry() { }

    public void Display()
    {
        Console.WriteLine($"Date: {_dateTime} - Prompt: {_prompt}");
        Console.Write($"{_entryText}");
    }

}