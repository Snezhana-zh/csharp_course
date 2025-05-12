using App.Practice3;
namespace AppTests.Practice3;

public class UserTests
{
    [Test]
    public void TestPasses_When_Get_Correct_Full_Name()
    {
        User user = new User(
            "new_user",
            "mySecurePassword123",
            "Мария",
            "Иванова",
            "998877665544",
            "+7 (912) 345-67-89");
        
        var actual = user.GetUserFullName();
        var expectedRes = "Мария " + "Иванова";
        Assert.That(actual, Is.EqualTo(expectedRes));
    }
    [Test]
    public void TestPasses_When_Successfully_Update_Phone()
    {
        User user = new User(
            "new_user",
            "mySecurePassword123",
            "Мария",
            "Иванова",
            "998877665544",
            "+7 (912) 345-67-89");

            var actual = user.TryUpdatePhone("89161234567");
            Assert.That(actual, Is.True);
    }
    [Test]
    public void TestPasses_When_Not_Update_Phone()
    {
        User user = new User(
            "new_user",
            "mySecurePassword123",
            "Мария",
            "Иванова",
            "998877665544",
            "+7 (912) 345-67-89");

        var actual = user.TryUpdatePhone("8916");
        Assert.That(actual, Is.False);
    }
}