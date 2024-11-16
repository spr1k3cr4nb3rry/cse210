using System;

public class ReflectionActivity : Activity
{
    protected override string GetName() => "Reflection";

    protected override string GetDescription() =>
        "Guides you through deep reflection on a positive experience.";

    public override void PerformActivity()
    {
        Console.WriteLine("Think about a time you demonstrated strength or succeeded.");
        Thread.Sleep(3000);

        string[] questions = {
            "What was the experience?",
            "How did it make you feel?",
            "What strengths did you show?",
            "How did you overcome any challenges?"
        };

        foreach (string question in questions)
        {
            Console.WriteLine(question);
            Countdown(5);
        }
    }
}
