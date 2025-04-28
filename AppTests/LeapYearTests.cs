using App;

namespace AppTests;

public class LeapYearTests
{
    [TestCase(2100, false)]
    [TestCase(2400, true)]
    [TestCase(2024, true)]
    [TestCase(2020, true)]
    [TestCase(2019, false)]
    public void TestPasses_When_Result_Correct(int year, bool expected)
    {
        var actual = LeapYear.IsLeapYear(year);
        Assert.That(actual, Is.EqualTo(expected));
    }
    [TestCase(0)]
    [TestCase(-1)]
    [TestCase(-100)]
    public void IsLeapYear_ThrowsArgumentOutOfRange_ForNonPositiveYears(int year)
    {
        Assert.That(() => LeapYear.IsLeapYear(year), Throws.TypeOf<ArgumentOutOfRangeException>());
    }
}