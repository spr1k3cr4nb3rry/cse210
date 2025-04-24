using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();
        int number = -1;
        int maximum = 0;
        int minimum = 1000;

        while (number != 0) {
            Console.Write("Enter number: ");
            number = Convert.ToInt32(Console.ReadLine());
            if (number != 0) {
                if (number > maximum) { maximum = number; }
                if (number < minimum && number > 0) { minimum = number; }
                numbers.Add(number);
            }
        }

        // Sum of the numbers in the list.
        int sum = 0;
        foreach (int num in numbers) { sum += num;}
        Console.WriteLine($"The sum is: {sum}");

        // Average of the numbers in the list.
        float average = (float)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        Console.WriteLine($"The largest number is: {maximum}");
        Console.WriteLine($"The smallest postive number is: {minimum}");

        Console.WriteLine("The sorted list is: ");
        numbers.Sort();
        foreach (int num in numbers) {
            Console.WriteLine(num);
        }
    }
}