using App.Practice4;
namespace AppTests.Practice4;

public class PolygonTests
{
    private const double Tolerance = 0.001;
    [Test]
    public void TestPasse_When_Triangle_Has_CorrectArea()
    {
        var a = new Vertex(0, 0);
        var b = new Vertex(0, 3);
        var c = new Vertex(4, 0);
        var triangle = new Triangle(a, b, c);
        
        var area = triangle.CalculateArea();
        Assert.That(6, Is.EqualTo(area).Within(Tolerance));
    }

    [Test]
    public void TestPasse_When_Triangle_Has_Correct_VertexCount()
    {
        var a = new Vertex(0, 0);
        var b = new Vertex(0, 3);
        var c = new Vertex(4, 0);
        var triangle = new Triangle(a, b, c);
        
        Assert.That(3, Is.EqualTo(triangle.VertexCount));
    }

    [Test]
    public void TestPasse_When_Rectangle_Has_CorrectArea()
    {
        var a = new Vertex(0, 0);
        var b = new Vertex(0, 5);
        var c = new Vertex(10, 5);
        var d = new Vertex(10, 0);
        var rectangle = new Rectangle(a, b, c, d);
        
        var area = rectangle.CalculateArea();
        Assert.That(50, Is.EqualTo(area).Within(Tolerance));
    }

    [Test]
    public void TestPasse_When_Rectangle_Has_Correct_VertexCount()
    {
        var a = new Vertex(0, 0);
        var b = new Vertex(0, 5);
        var c = new Vertex(10, 5);
        var d = new Vertex(10, 0);
        var rectangle = new Rectangle(a, b, c, d);

        Assert.That(4, Is.EqualTo(rectangle.VertexCount));
    }

    [Test]
    public void ArgumentException_When_Is_Not_Triangle()
    {
        var a = new Vertex(0, 0);
        var b = new Vertex(0, 0);
        var c = new Vertex(0, 5);
        
        Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
    }
    [Test]
    public void ArgumentException_When_Is_Not_Rectangle()
    {
        var a = new Vertex(0, 0);
        var b = new Vertex(0, 0);
        var c = new Vertex(0, 5);
        var d = new Vertex(0, 5);
        
        Assert.Throws<ArgumentException>(() => new Rectangle(a, b, c, d));
    }
    [Test]
    public void ArgumentException_When_Is_Not_Square()
    {
        var a = new Vertex(0, 0);
        var b = new Vertex(0, 5);
        var c = new Vertex(10, 5);
        var d = new Vertex(10, 0);
        
        Assert.Throws<ArgumentException>(() => new Square(a, b, c, d));
    }
}