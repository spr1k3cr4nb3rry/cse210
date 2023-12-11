using System;
using System.Diagnostics;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    
    public Activity()
    {
        _name = "";
        _description = "";
        _duration = 15;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public void ShowDetails()
    {
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
    }

    public void AskDuration()
    {
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        string durationString = Console.ReadLine();
        SetDuration(Convert.ToInt32(durationString));
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void RunActivity()
    {
        Console.Clear();
        ShowDetails();
        AskDuration();
        GetReady();
    }

    public void EndActivity()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"Well done!!");
        GenerateSpinnerOrCountdown(5, true);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        GenerateSpinnerOrCountdown(5, true);
    }

    public void GenerateSpinnerOrCountdown(int totalSeconds, bool isSpinner)
    {
        int position = Console.CursorLeft;
        int waitTime = isSpinner ? 500 : 1000;

        for (int i = 0; i <= totalSeconds; i++)
        {
            Console.CursorLeft = position;
            Console.Write(isSpinner ? "|/-\\"[i % 4] : totalSeconds - i);
            Thread.Sleep(waitTime);
        }

        Console.CursorLeft = position;
        Console.Write(" ");
    }

    public void GetReady()
    {
        Console.Clear();
        Console.WriteLine("Get Ready...");
        GenerateSpinnerOrCountdown(5, true);
    }

    public DateTime GetFutureTime(int duration)
    {   
        DateTime futureTime = new DateTime();
        futureTime = DateTime.Now.AddSeconds(duration);

        return futureTime;
    }

    public DateTime GetCurrentTime()
    {
        DateTime currentTime = new DateTime();
        currentTime = DateTime.Now;
        return currentTime;
    }
}