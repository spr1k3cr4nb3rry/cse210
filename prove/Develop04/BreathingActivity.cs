using System;

public class BreathingActivity : Activity
{
    override string GetName() => "Breathing";

    override string GetDescription() =>
        "Guides you to pace your breathing for relaxation.";

    public override void PerformActivity()
    {
        Console.WriteLine("Focus on deep, slow breathing. Inhale and exhale slowly.");
        for (int i = 0; i < Duration / 5; i++)
        {
            Console.WriteLine("Inhale deeply...");
            Thread.Sleep(2500);
            Console.WriteLine("Exhale slowly...");
            Thread.Sleep(2500);
        }
    }
}