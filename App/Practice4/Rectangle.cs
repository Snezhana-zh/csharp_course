namespace App.Practice4;

public class Rectangle : Polygon
{
    public Rectangle(Vertex a, Vertex b, Vertex c, Vertex d) : base(a, b, c, d) 
    {
        if (!IsValidPolygon()) throw new ArgumentException("Invalid Rectangle");
    }
    protected override bool IsValidPolygon()
    {
        return IsRightAngle(Vertices[0], Vertices[1], Vertices[2]) 
               && IsRightAngle(Vertices[1], Vertices[2], Vertices[3]) 
               && IsRightAngle(Vertices[3], Vertices[2], Vertices[0]);
    }
    private bool IsRightAngle(Vertex a, Vertex b, Vertex c)
    {
        return (b.X - a.X) * (c.X - b.X) + (b.Y - a.Y) * (c.Y - b.Y) < Tolerance 
               && !a.IsEqual(b) && !a.IsEqual(c) && !b.IsEqual(c);
    }
    public override double CalculateArea()
    {
        return GetDistance(Vertices[0], Vertices[1]) * GetDistance(Vertices[1], Vertices[2]);
    }
}