using App.Practice2;

namespace AppTests.Practice2;

public class PhoneNumberTests
{
    [TestCase("+7-983-313-6827", true, "+79833136827")]
    [TestCase("перезвонить по номеру 89833136827 завтра", true, "+79833136827")]
    [TestCase("8(983)-313-68-27", true, "+79833136827")]
    [TestCase("Мой номер +7 983 313-68-27, а код 4567", true, "+79833136827")]
    [TestCase("8983-313-68-27", true, "+79833136827")]
    [TestCase("Мой номер ---983 313-68-27, а код 4567", false, null)]
    [TestCase("Мой номер +8983 313-68-27, а код 4567", false, null)]
    [TestCase("Мой номер +983 313-68-27, а код 4567", false, null)]
    [TestCase("Мой номер +9 983 313-68-27, а код 4567", false, null)]
    [TestCase("Мой номер 79833136827, а код 4567", true, "+79833136827")]
    [TestCase("Мой номер +10-983-313-68-27, а код 4567", false, null)]
    public void TestPasses_When_Result_Correct(string msg, bool expectedRes, string expectedPhone)
    {
        var actual = PhoneNumber.TryParsePhone(msg, out var res);
        Assert.That(actual, Is.EqualTo(expectedRes));
        Assert.That(res, Is.EqualTo(expectedPhone));
    }
}