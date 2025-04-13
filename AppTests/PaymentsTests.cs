using App;

namespace AppTests;

public class PaymentsTests
{
    [TestCase(PaymentsPlan.Annuity, 7, 3, 10000, 10116.89)]
    [TestCase(PaymentsPlan.Differentiated, 3, 5, 200000, 201500)]
    [TestCase(PaymentsPlan.Annuity, 25, 36, 5000000, 7156768.68)]
    [TestCase(PaymentsPlan.Differentiated, 25, 36, 5000000, 6927083.33)]
    public void TestPasses_When_Result_Correct(PaymentsPlan plan, decimal rate, int monthsCount, decimal amount, decimal expected)
    {
        var actual = Payments.CalculateTotalPayments(plan, rate, monthsCount, amount);
        Assert.That(actual, Is.EqualTo(expected).Within(1e-1));
    }
}