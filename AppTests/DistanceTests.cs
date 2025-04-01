using App;

namespace AppTests;

public class DistanceTests
{
    //TODO напишите свои тесты
    [TestCase(1, 1, 1, 1, 1, 1, 1)]
    public void TestPasses_When_Result_Correct(
        // позиция курсора
        double x, double y,
        // отрезок
        double x1, double y1, double x2, double y2,
        double expected)
    {
        var actual = Distance.DistanceToSegment(x, y, x1, y1, x2, y2);
        Assert.That(actual, Is.EqualTo(expected));
    }
}