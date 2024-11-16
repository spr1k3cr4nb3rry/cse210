using System;
using System.Threading;

public class Menu
{
    public void Display ()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness App");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an activity: ");
            string choice = Console.ReadLine();

            Activity activity;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    Console.WriteLine("Exiting the Mindfulness App. Take care!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    System.Threading.Thread.Sleep(2000);
                    continue;
            }

            activity.Start();
            activity.PerformActivity();
            activity.End();
        }
    }
}