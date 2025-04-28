using App;

namespace AppTests;

public class RectanglesTests
{
    [TestCase(0, 0, 1, 1, 1, 1, 2, 2, true, Description = "Соприкасаются углами")]
    [TestCase(0, 0, 1, 1, 2, 2, 3, 3, false, Description = "Не пересекаются")]
    [TestCase(0, 0, 0, 0, 2, 2, 2, 2, false, Description = "Не пересекаются точки")]
    [TestCase(0, 0, 2, 2, 1, 1, 3, 3, true, Description = "Пересекаются")]
    [TestCase(0, 0, 2, 2, 2, 1, 4, 3, true, Description = "Пересекающиеся по вертикали")]
    [TestCase(0, 0, 2, 2, 0, 2, 2, 4, true, Description = "Пересекающиеся по горизонтали")]
    [TestCase(0, 0, 2, 2, 0, 0, 2, 2, true, Description = "Совпадают")]
    [TestCase(0, 0, 2, 2, 1, 1, 1, 1, true, Description = "Точка внутри")]
    [TestCase(0, 0, 0, 0, 0, 0, 0, 0, true, Description = "Две одинаковые точки")]
    [TestCase(0, 0, 0, 5, 0, 2, 0, 3, true, Description = "Пересекающиеся линии по вертикали")]
    [TestCase(0, 0, 5, 0, 2, 0, 3, 0, true, Description = "Пересекающиеся линии по горизонтали")]
    public void TestPasses_When_IsIntersectedResult_Correct(
        // первый прямоугольник
        int x1, int y1, int x2, int y2,
        // второй прямоугольник
        int x3, int y3, int x4, int y4,
        bool expected)
    {
        var actual = Rectangles.IsIntersected(x1, y1, x2, y2, x3, y3, x4, y4);
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    
    [TestCase(0, 0, 3, 3, 1, 1, 2, 2, true)]
    [TestCase(0, 0, 1, 1, 1, 1, 2, 2, false)]
    [TestCase(0, 0, 1, 1, 2, 2, 3, 3, false)]
    [TestCase(0, 0, 5, 5, 1, 1, 6, 6, false)]
    [TestCase(0, 0, 2, 2, 0, 0, 2, 2, true, Description = "Совпадают")]
    [TestCase(0, 0, 2, 2, 1, 1, 1, 1, true, Description = "Точка внутри")]
    [TestCase(0, 0, 0, 0, 0, 0, 0, 0, true, Description = "Две одинаковые точки")]
    public void TestPasses_WhenIsNestedResult_Correct(
        // первый прямоугольник
        int x1, int y1, int x2, int y2,
        // второй прямоугольник
        int x3, int y3, int x4, int y4,
        bool expected)
    {
        var actual = Rectangles.IsNested(x1, y1, x2, y2, x3, y3, x4, y4);
        Assert.That(actual, Is.EqualTo(expected));
    }
}