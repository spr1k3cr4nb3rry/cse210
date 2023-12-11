using System;
public class BreathingActivity : Activity
{  
    public BreathingActivity()
    {
        SetName("Breathing Activity");
        SetDescription("This activity will help you relax by walking through your breathing in and out slowly. Clear your mind and focus on your breathing.");
    }
    
    public void PromptBreathing()
    {
        DateTime futureTime = GetFutureTime(GetDuration());
        DateTime currentTime = GetCurrentTime();
        
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Breathe in...");
        GenerateSpinnerOrCountdown(2, false);
        Console.WriteLine();
        Console.Write("Breathe out...");
        GenerateSpinnerOrCountdown(3, false);

        while (currentTime <= futureTime)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Breathe in...");
            GenerateSpinnerOrCountdown(4, false);
            Console.WriteLine();
            Console.Write("Breathe out...");
            GenerateSpinnerOrCountdown(6, false);
            currentTime = DateTime.Now;
        }
    }
}