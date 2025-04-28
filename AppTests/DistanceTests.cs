using App;

namespace AppTests;

public class DistanceTests
{
    private const double Sqrt2 = 1.4142135623730951;
    private const double Error = 1e-6;
    [TestCase(1, 1, 1, 1, 1, 1, 0)]
    [TestCase(2, 0, 0, 0, 1, 1, Sqrt2)]
    [TestCase(0, 1, 0, 0, 1, 1, (Sqrt2/2.0))]
    [TestCase(2, 0, -1, -1, 0, 0, 2)]
    public void TestPasses_When_Result_Correct(
        // позиция курсора
        double x, double y,
        // отрезок
        double x1, double y1, double x2, double y2,
        double expected)
    {
        var actual = Distance.DistanceToSegment(x, y, x1, y1, x2, y2);
        Assert.That(actual, Is.EqualTo(expected).Within(Error));
    }
}