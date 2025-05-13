namespace App.Practice4;

public class Vertex : I2DVertex
{
    private const double Tolerance = 1e-10;
    public double X { get; set; }
    public double Y { get; set; }
    
    public Vertex(double x, double y)
    {
        X = x;
        Y = y;
    }

    public bool IsEqual(Vertex other)
    {
        return Math.Abs(X - other.X) < Tolerance && 
               Math.Abs(Y - other.Y) < Tolerance;
    }
    public override string ToString()
    {
        return $"(x = {X:F3}, y = {Y:F3})";
    }
}