public class Entry
{
    public DateTime _date;
    public string _prompt;
    public string _response;

    public Entry(DateTime date, string prompt, string response) {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public void Display() {
        Console.WriteLine($"Date: {_date.ToShortDateString()} - Prompt: {_prompt}\n{_response}\n");
    }
}
