using System;

public class ListingActivity : Activity
{
    protected override string GetName() => "Listing";

    protected override string GetDescription() =>
        "Helps you list positive aspects, strengths, or accomplishments.";

    public override void PerformActivity()
    {
        Console.WriteLine("List as many positive aspects, strengths, or accomplishments as you can.");
        Thread.Sleep(2000);
        Console.WriteLine("Start listing!");
        Countdown(Duration);
        Console.WriteLine("Time to wrap up your list.");
    }
}