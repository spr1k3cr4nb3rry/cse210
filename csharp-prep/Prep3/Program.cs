/* 
   Name: Izzie Vazquez
   Assignment Name: Learning Activity - C# Prep 3
   Assignment Description: In the Guess My Number game the computer picks a magic number, and then the user tries to guess it. After each guess, the computer tells the user to guess "higher" or "lower" until they guess the magic number.
   Reflection:
   Time taken:
*/
using System;

class Program
{
    static void Main(string[] args) {
        Console.Write("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());

        int guess = -1;

        while (guess != magicNumber) {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
        } 
    }
}