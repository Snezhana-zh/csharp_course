using App.Practice2;

namespace AppTests.Practice2;

public class StackMachineTests
{
    [TestCase(new string[]
    {
        "push Привет! Это снова я! Пока!",
        "pop 5",
        "push Как твои успехи? Плохо?",
        "push qwertyuiop",
        "push 1234567890",
        "pop 27"
        
    }, "Привет! Это снова я! Как твои успехи?")]
    [TestCase(new string[]
    {
        "push Привет!",
        "pop 7"
    }, "")]
    [TestCase(new string[]
    {
        "push Привет!",
        "pop 0"
    }, "Привет!")]
    [TestCase(new string[]
    {
        "push Привет ",
        "push !"
    }, "Привет !")]
    public void TestPasses_When_StackMachine_Return_Correct_String(string[] lines, string expected)
    {
        var actual = StackMachine.CalculateString(lines);
        Assert.That(actual, Is.EqualTo(expected));
    }
}