// Create prototypes
var originalCircle = new Circle()
{
    Radius = 5,
    Coordinate = new(1, 2, 3)
};

// Clone prototypes
var cloned1 = originalCircle.CloneAll();
(cloned1 as Circle).Radius = 15;


// Clone prototypes
var cloned2 = originalCircle.CloneSize();


// Render original and cloned shapes
Console.WriteLine("Original Shape:");
originalCircle.Render();

Console.WriteLine("Cloned and Modified Shape:");
cloned1.Render();
cloned2.Render();


public interface IShape
{
    IShape CloneSize();
    IShape CloneAll();
    void Render();
}

public class Circle : IShape
{
    public Coordinate Coordinate { get; set; } = default!;
    public int Radius { get; set; } = default;

    public IShape CloneAll() => new Circle()
    {
        Radius = Radius,
        Coordinate = new(Coordinate.X, Coordinate.Y, Coordinate.Z),
    };
    public IShape CloneSize() => new Circle()
    {
        Radius = Radius,
        Coordinate = new(0, 0, 0),
    };

    public void Render() => Console.WriteLine($"Rendering a circle with radius {Radius} in {Coordinate.X}:{Coordinate.Y}:{Coordinate.Z}");

}
public class Coordinate
{
    public Coordinate(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
}