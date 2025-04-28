using App;

namespace AppTests;

public class PricesTests
{
    [TestCase(1, "рубль")]
    [TestCase(2, "рубля")]
    [TestCase(3, "рубля")]
    [TestCase(4, "рубля")]
    [TestCase(5, "рублей")]
    [TestCase(6, "рублей")]
    [TestCase(7, "рублей")]
    [TestCase(8, "рублей")]
    [TestCase(9, "рублей")]
    [TestCase(10, "рублей")]
    [TestCase(20, "рублей")]
    [TestCase(22, "рубля")]
    [TestCase(23, "рубля")]
    [TestCase(24, "рубля")]
    [TestCase(25, "рублей")]
    [TestCase(26, "рублей")]
    [TestCase(27, "рублей")]
    [TestCase(28, "рублей")]
    [TestCase(29, "рублей")]
    [TestCase(111, "рублей")]
    [TestCase(122, "рубля")]
    [TestCase(126, "рублей")]
    [TestCase(1000, "рублей")]
    [TestCase(1002, "рубля")]
    [TestCase(1004, "рубля")]
    [TestCase(1005, "рублей")]
    [TestCase(100008, "рублей")]
    [TestCase(100009, "рублей")]
    [TestCase(1000052, "рубля")]
    [TestCase(1000055, "рублей")]
    public void TestPasses_When_Result_Correct(int price, string expected)
    {
        var actual = Prices.GetCurrencyAlias(price, false, false);
        Assert.That(actual, Is.EqualTo(expected));
    }
}