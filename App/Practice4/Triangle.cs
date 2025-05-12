namespace App.Practice4;

public sealed class Triangle : Polygon
{
    public Triangle(Vertex a, Vertex b, Vertex c) : base(a, b, c)
    {
        if (!IsValidPolygon()) throw new ArgumentException("Invalid Triangle");
    }

    protected override bool IsValidPolygon()
    {
        var a = GetDistance(Vertices[0], Vertices[1]);  
        var b = GetDistance(Vertices[1], Vertices[2]);
        var c = GetDistance(Vertices[0], Vertices[2]);
        return (a + b >= c) && (a + c >= b) && (b + c >= a) 
               && !a.Equals(b) && !a.Equals(c) && !b.Equals(c);
    }
    
    public override double CalculateArea()
    {
        var a = Vertices[0];
        var b = Vertices[1];
        var c = Vertices[2];
        
        return Math.Abs((b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X)) / 2;
    }
}