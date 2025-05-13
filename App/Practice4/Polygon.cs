namespace App.Practice4;

public abstract class Polygon : IGeometry
{
    private readonly Vertex[] _vertices;
    public Vertex[] Vertices => _vertices;
    
    protected const double Tolerance = 1e-10;
    
    protected Polygon(params Vertex[] vertices)
    {
        _vertices = vertices;
    }
    public abstract double CalculateArea();
    
    public int VertexCount => _vertices.Length;
    protected abstract bool IsValidPolygon();
    
    protected double GetDistance(Vertex a, Vertex b)
    {
        return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
    }
}