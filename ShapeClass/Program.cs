using System;

public class Shape
{
    public string Name { get; }

    public Shape(string name)
    {
        Name = name;
    }

    public virtual double CalculateArea()
    {
        return 0.0d; // Default implementation of area calculation for all shapes except circles and rectangles
    }
}

public class Circle : Shape
{
    public double Radius { get; }

    public Circle(double radius) : base("Circle")
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}

public class Rectangle : Shape
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height) : base("Rectangle")
    {
        Width = width;
        Height = height;
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

public class Triangle : Shape
{
    public double BaseLength { get; }
    public double Height { get; }

    public Triangle(double baseLength, double height) : base("Triangle")
    {
        BaseLength = baseLength;
        Height = height;
    }

    public override double CalculateArea()
    {
        return BaseLength * Height / 2;
    }
}

public class Program
{
    public static void Main()
    {
        Shape circle = new Circle(5.0);
        PrintShapeArea(circle);

        Shape rectangle = new Rectangle(4.0, 6.0);
        PrintShapeArea(rectangle);

        Shape triangle = new Triangle(3.0, 5.0);
        PrintShapeArea(triangle);
    }

    public static void PrintShapeArea(Shape shape)
    {
        Console.WriteLine($"The area of the {shape.Name} is: {shape.CalculateArea()}");
    }
}
