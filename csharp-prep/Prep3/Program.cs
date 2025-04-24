using System;

class Program
{
    static void Main(string[] args)
    {
        bool continueGame = true;
        while (continueGame) {
            Random randomGen = new Random();
            int magicNumber = randomGen.Next(1, 101);

            int guess = -1;
            int guessCount = 0;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess > magicNumber) {
                    Console.WriteLine("Lower!");
                }
                else {
                    Console.WriteLine("Higher!");
                }
            }

            Console.WriteLine($"You guessed the number in {guessCount} guesses! The number was {magicNumber}.");

            Console.Write("Play again? (y/n) ");
            string answer = Console.ReadLine();
            if (answer == "n") {
                continueGame = false;
            }
        }
    }
}