using System;
using System.Threading;
using System.Diagnostics.Contracts;

public class Activity
{
    protected int Duration;

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Starting '{GetName()}' Activity - {GetDescription()}");
        Console.Write("Enter duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Countdown(3);
        Console.Clear();
        Console.WriteLine($"Starting '{GetName()}' Activity for {Duration} seconds.");
    }

    public void End()
    {
        Console.WriteLine("\nGood job! You've completed the activity.");
        Thread.Sleep(2000);
        Console.WriteLine($"You completed the '{GetName()}' Activity for {Duration} seconds.");
        Thread.Sleep(2000);
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i} seconds remaining...  ");
            Thread.Sleep(1000);
        }
        Console.WriteLine("\rTime's up!               ");
    }

    public string GetName();
    public string GetDescription();
    public void PerformActivity();
}