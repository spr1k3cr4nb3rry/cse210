/*
File: Program.cs
Author: Izzie Vazquez
Overview: An iconic line from the James Bond movies is that he would introduce himself as "Bond, James Bond." 
For this assignment you will write a program that asks for your name and repeats it back in this way.
Assignment: Prompt the user for their first name. Then, prompt them for their last name. Display the text back all
on one line saying, "Your name is last-name, first-name, last-name".
*/
using System;
class Program {
    static void Main(string[] args) {
        // User inputs first name.
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // User inputs last name.
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Returns inputted first + last name in a James Bond fashion.
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}