public class JournalEntry
{
    public DateTime Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public JournalEntry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now;
    }

    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {Date.ToShortDateString()} - Prompt: {Prompt}\n{Response}\n");
    }
}
