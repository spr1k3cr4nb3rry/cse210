class Shape {
    // Fields
    private string _color;

    // Methods
    public static double GetArea(double length, double width) {
        return length * width;
    }

    // Getter / Setter for Color
    public string Color {
        get { return _color; }
        set { _color = value; }
    }

    // Constructor
    public Shape(string color) { 
        _color = color;
    }
}