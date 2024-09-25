/* 
   Name: Izzie Vazquez
   Assignment Name: Learning Activity - C# Prep 3
   Assignment Description: In the Guess My Number game the computer picks a magic number, and then the user tries to guess it. After each guess, the computer tells the user to guess "higher" or "lower" until they guess the magic number.
*/
using System;

class Program
{
    static void Main(string[] args) // The entry point for the number-guessing game.
    {
        string continueGame = "y";
        while (continueGame == "y")
        {
            Random randomGen = new Random();
            int magicNumber = randomGen.Next(1, 101);

            int guess = -1;
            int guessCount = 0;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower!");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher!");
                }
            }

            Console.WriteLine($"You guessed the number in {guessCount} guesses! The number was {magicNumber}.");
            Console.Write("Play again? (y/n) ");
            continueGame = Console.ReadLine();
        }
    }
}