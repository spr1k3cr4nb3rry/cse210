using System;

class Rectangle {

}

class Circle {

}

class Program {
    static void Main(string[] args)
    {
        Shape newShape = new Shape("red");
        Console.WriteLine(newShape.Color);
    }
}