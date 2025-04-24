using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter your grade percentage: ");
        int percentage = Convert.ToInt32(Console.ReadLine());
        char letter;
        char modifier = ' ';
        bool pass = true;

        if (percentage >= 90) {
            letter = 'A';
        } else if (percentage >= 80) {
            letter = 'B';
        } else if (percentage >= 70) {
            letter = 'C';
        } else if (percentage >= 60) {
            letter = 'D';
            pass = false;
        } else {
            letter = 'F';
            pass = false;
        }

        if (percentage % 10 >= 7 && letter != 'A' && letter != 'F') {
                modifier = '+';
        } else if (percentage % 10 < 3 && letter != 'F') {
            modifier = '-';
        }

        if (pass) {
            Console.WriteLine($"Your letter grade is {letter}{modifier}. Congratulations, you passed this class!");
        } else {
            Console.WriteLine($"Your letter grade is {letter}{modifier}. Unfortunately, you did not pass this class. Better luck next time!");
        }
    }
}