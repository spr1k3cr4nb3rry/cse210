using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.Design;

public class Journal
{
    private List<Entry> _entries = new();
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

    public void Menu() {
        Console.WriteLine("Welcome to the Journal Program!");
        while (true) {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    Write();
                    break;
                case "2":
                    Display();
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

    private void Write() {
        Random random = new();
        string prompt = _prompts[random.Next(_prompts.Length)];
        Console.WriteLine(prompt);
        string response = Console.ReadLine();
        DateTime date = DateTime.Now;
        _entries.Add(new Entry(date, prompt, response));
    }

    void Display() {
        foreach (Entry entry in _entries) {
            entry.Display();
        }
    }

    void Load() {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();

        try {
            _entries.Clear();
            using (StreamReader file = new(filename)) {
                string line;
                while ((line = file.ReadLine()) != null) {
                    string prompt = line;
                    string response = file.ReadLine();
                    DateTime date = DateTime.Parse(file.ReadLine());
                    _entries.Add(new Entry(date, prompt, response));
                }
            }
        } catch (FileNotFoundException) {
            Console.WriteLine("Error: File not found.");
        } catch (UnauthorizedAccessException) {
            Console.WriteLine("Error: Access to the file is denied.");
        } catch (DirectoryNotFoundException) {
           Console.WriteLine("Error: Directory not found.");
        } catch (IOException ex) {
            Console.WriteLine($"An I/O error occurred: {ex.Message}");
        } catch (FormatException) {
            Console.WriteLine("Error: File format is invalid.");
        } catch (Exception ex) {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }  
    }

    void Save() {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();

        try {
            using (StreamWriter file = new StreamWriter(filename)) {
                foreach (Entry entry in _entries) {
                    file.WriteLine(entry._prompt);
                    file.WriteLine(entry._response);
                    file.WriteLine(entry._date);
                }
            }
            Console.WriteLine("File saved successfully.");
        } catch (UnauthorizedAccessException) {
            Console.WriteLine("Error: Access to the file is denied.");
        } catch (DirectoryNotFoundException) {
            Console.WriteLine("Error: Directory not found.");
        } catch (IOException ex) {
            Console.WriteLine($"An I/O error occurred: {ex.Message}");
        } catch (Exception ex) {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}
