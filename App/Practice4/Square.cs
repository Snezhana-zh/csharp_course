namespace App.Practice4;

public sealed class Square : Rectangle
{
    public Square(Vertex a, Vertex b, Vertex c, Vertex d) : base(a, b, c, d)
    {
        if (!IsValidPolygon()) throw new ArgumentException("Invalid Square");
    }
    protected override bool IsValidPolygon()
    {
        return Math.Abs(GetDistance(Vertices[0], Vertices[1]) - GetDistance(Vertices[1], Vertices[2])) < Tolerance;
    }
}