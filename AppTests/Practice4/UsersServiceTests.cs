using App.Practice4;
using App.Practice4.Dto;
using App.Practice4.Services;
namespace AppTests.Practice4;

public class UsersServiceTests
{
    private UsersService _usersService;
        
    [SetUp]
    public void Setup()
    {
        _usersService = new UsersService();
    }
    
    [Test]
    public void CreateUser_ReturnsNonEmptyGuid()
    {
        var user = new CreateUserDto
        {
            Login = "testuser",
            Password = "password123",
            Name = "Test",
            Surname = "User",
            Inn = "540697278456",
            Phone = "89138888888"
        };

        var userId = _usersService.CreateUser(user);

        Assert.That(userId, Is.Not.EqualTo(Guid.Empty));
    }
    [Test]
    public void CreateUser_WithExistingLogin_ThrowsException()
    {
        var user = new CreateUserDto
        {
            Login = "testuser",
            Password = "password123",
            Name = "Test",
            Surname = "User",
            Inn = "540697278456",
            Phone = "89138888888"
        };
        
        var existingUser = new CreateUserDto
        {
            Login = "testuser",
            Password = "pass123",
            Name = "Test",
            Surname = "User"
        };
        _usersService.CreateUser(user);
        Assert.Throws<Exception>(() => _usersService.CreateUser(existingUser), "User already exists.");
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    public void CreateUser_WithInvalidLogin_ThrowsException(string invalidLogin)
    {
        var dto = new CreateUserDto
        {
            Login = invalidLogin,
            Password = "pass123",
            Name = "Test",
            Surname = "User",
            Inn = "540697278456",
            Phone = "89138888888"
        };
        Assert.Throws<Exception>(() => _usersService.CreateUser(dto), "Invalid login.");
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    public void CreateUser_WithInvalidPassword_ThrowsException(string invalidPassword)
    {
        var dto = new CreateUserDto
        {
            Login = "testuser",
            Password = invalidPassword,
            Name = "Test",
            Surname = "User"
        };

        Assert.Throws<Exception>(() => _usersService.CreateUser(dto), "Invalid password.");
    }
    
    [TestCase("9729219090", typeof(Employee))]   // 10 цифр - Employee
    [TestCase("540697278456", typeof(Seller))]   // 12 цифр - Seller
    [TestCase(null, typeof(Customer))]           // null - Customer
    public void CreateUser_WithValidInn_CreatesCorrectUserType(string inn, Type expectedType)
    {
        var dto = new CreateUserDto
        {
            Login = "login",
            Password = "pass123",
            Name = "Test",
            Surname = "User",
            Inn = inn,
            Phone = "89138888888"
        };

        var userId = _usersService.CreateUser(dto);
        var user = _usersService.GetUser(userId);

        Assert.That(user, Is.InstanceOf(expectedType));
    }

    [Test]
    public void GetUser_ReturnsCreatedUser()
    {
        var createUserDto = new CreateUserDto
        {
            Login = "testuser",
            Password = "password123",
            Name = "Test",
            Surname = "User",
            Inn = "540697278456",
            Phone = "89138888888"
        };
        var userId = _usersService.CreateUser(createUserDto);

        var user = _usersService.GetUser(userId);
        
        Assert.That(user, Is.Not.Null);
        Assert.That(user.Name, Is.EqualTo(createUserDto.Name));
        Assert.That(user.Surname, Is.EqualTo(createUserDto.Surname));
        Assert.That(user.Login, Is.EqualTo(createUserDto.Login));
    }

    [TestCase("name1", "surname1", "+79138888888")]
    [TestCase("name2", null, null)]
    [TestCase(null, "surname2", null)]
    public void UpdateUser_ChangesSpecifiedProperties(string name, string surname, string phone)
    {
        var userId = _usersService.CreateUser(new CreateUserDto
        {
            Login = "login",
            Password = "pass",
            Name = "name",
            Surname = "surname",
            Inn = "540697278456",
            Phone = "89138888888"
        });

        _usersService.UpdateUser(userId, new UpdateUserDto
        {
            Name = name,
            Surname = surname,
            Phone = phone,
            Inn = "540697278456"
        });

        var updatedUser = _usersService.GetUser(userId);
        
        Assert.That(updatedUser.Name, Is.EqualTo(name ?? "name"));
        Assert.That(updatedUser.Surname, Is.EqualTo(surname ?? "surname"));
        Assert.That(updatedUser.Phone, Is.EqualTo(phone ?? "+79138888888"));
    }

    [Test]
    public void ChangePassword_WithCorrectOldPassword_UpdatesPassword()
    {
        var userId = _usersService.CreateUser(new CreateUserDto
        {
            Login = "login",
            Password = "oldpass",
            Name = "Test",
            Surname = "User",
            Inn = "540697278456",
            Phone = "89138888888"
        });

        _usersService.ChangePassword(userId, "oldpass", "newpass");
        
        var user = _usersService.GetUser(userId);
        
        Assert.That(user.HasPassword("newpass"), Is.True);
    }

    [Test]
    public void ChangePassword_WithWrongOldPassword_ThrowsException()
    {
        var userId = _usersService.CreateUser(new CreateUserDto
        {
            Login = "wrongpass",
            Password = "correct",
            Name = "Test",
            Surname = "User",
            Inn = "540697278456",
            Phone = "89138888888"
        });

        Assert.Throws<Exception>(() => 
            _usersService.ChangePassword(userId, "wrong", "newpass"),
            "Old password is incorrect.");
    }
    
    [Test]
    public void ChangePassword_WithOldPassword_ThrowsException()
    {
        var userId = _usersService.CreateUser(new CreateUserDto
        {
            Login = "wrongpass",
            Password = "correct",
            Name = "Test",
            Surname = "User",
            Inn = "540697278456",
            Phone = "89138888888"
        });

        Assert.Throws<Exception>(() => 
                _usersService.ChangePassword(userId, "correct", "correct"),
            "Password already used.");
    }

    [Test]
    public void DeleteUser_RemovesUserFromSystem()
    {
        var userId = _usersService.CreateUser(new CreateUserDto
        {
            Login = "login",
            Password = "pass",
            Name = "Test",
            Surname = "User",
            Inn = "540697278456",
            Phone = "89138888888"
        });

        _usersService.DeleteUser(userId);

        Assert.That(() => _usersService.GetUser(userId),
            Throws.Exception);
    }

    [TestCase("validuser", "correctpass", ExpectedResult = true)]
    [TestCase("validuser", "wrongpass", ExpectedResult = false)]
    [TestCase("nonexistent", "pass", ExpectedResult = false)]
    public bool LogIn_ReturnsExpectedResult(string login, string password)
    {
        _usersService.CreateUser(new CreateUserDto
        {
            Login = "validuser",
            Password = "correctpass",
            Name = "Test",
            Surname = "User",
            Inn = "540697278456",
            Phone = "89138888888"
        });

        try
        {
            _usersService.LogIn(login, password);
            return true;
        }
        catch
        {
            return false;
        }
    }
}