using App;

namespace AppTests;

public class PricesTests
{
    [TestCase(1, "рубль")]
    [TestCase(2, "рубля")]
    [TestCase(5, "рублей")]
    
    [TestCase(0, "рублей")]
    [TestCase(10, "рублей")]
    [TestCase(11, "рублей")]
    [TestCase(12, "рублей")]
    [TestCase(20, "рублей")]
    [TestCase(21, "рубль")]
    [TestCase(22, "рубля")]
    [TestCase(25, "рублей")]
    
    [TestCase(100, "рублей")]
    [TestCase(101, "рубль")]
    [TestCase(102, "рубля")]
    [TestCase(105, "рублей")]
    [TestCase(111, "рублей")]
    [TestCase(121, "рубль")]
    [TestCase(1000052, "рубля")]
    public void TestPasses_When_Result_Correct(int price, string expected)
    {
        var actual = Prices.GetCurrencyAlias(price, false, false);
        Assert.That(actual, Is.EqualTo(expected));
    }
}