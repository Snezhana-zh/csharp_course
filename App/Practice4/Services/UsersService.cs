using System.Reflection;
using System.Runtime.InteropServices;
using App.Practice4.Dto;
namespace App.Practice4.Services;

public class UsersService : IUsersService
{
    private readonly Dictionary<Guid, User> _users = new();
    private readonly Dictionary<string, Guid> _usersByLogin = new();
    
    public User GetUser(Guid userId)
    {
        if (!_users.TryGetValue(userId, out var user))
            throw new Exception("User not found.");
        return user;
    }

    public Guid CreateUser(CreateUserDto createUserDto)
    {
        if (string.IsNullOrWhiteSpace(createUserDto.Login))
            throw new Exception("Invalid login.");
        if (string.IsNullOrWhiteSpace(createUserDto.Password))
            throw new Exception("Invalid password.");
        
        if (_usersByLogin.ContainsKey(createUserDto.Login))
            throw new Exception("User already exists.");
        
        User newUser = createUserDto.Inn switch
        {
            not null when createUserDto.Inn.Length == 10 => new Employee(),
            not null when createUserDto.Inn.Length == 12 => new Seller(),
            null => new Customer(),
            _ => throw new Exception("Invalid inn length or missing inn for creating user.")
        };
        
        newUser.Login = createUserDto.Login;
        newUser.PasswordHash = createUserDto.Password;
        newUser.Name = string.IsNullOrWhiteSpace(createUserDto.Name) ? String.Empty : createUserDto.Name;
        newUser.Surname = string.IsNullOrWhiteSpace(createUserDto.Surname) ? String.Empty : createUserDto.Surname;
        newUser.Phone = string.IsNullOrWhiteSpace(createUserDto.Phone) ? String.Empty : createUserDto.Phone; ;
        newUser.Inn = string.IsNullOrWhiteSpace(createUserDto.Inn) ? String.Empty : createUserDto.Inn;
        
        _users.Add(newUser.Id, newUser);
        _usersByLogin.Add(newUser.Login, newUser.Id);
        return newUser.Id;
    }

    public void DeleteUser(Guid userId)
    {
        var user = GetUser(userId);
        _usersByLogin.Remove(user.Login);
        _users.Remove(userId);
    }

    public void ChangePassword(Guid userId, string oldPassword, string newPassword)
    {
        var user = GetUser(userId);
        if (!user.HasPassword(oldPassword))
            throw new Exception("Old password is incorrect.");
        if (user.HasPassword(newPassword))
            throw new Exception("Password already used.");
        user.PasswordHash = newPassword;
    }

    public void UpdateUser(Guid userId, UpdateUserDto updateUserDto)
    {
        var user = GetUser(userId);
        user.Name = updateUserDto.Name ?? user.Name;
        user.Surname = updateUserDto.Surname ?? user.Surname;
        user.Phone = updateUserDto.Phone ?? user.Phone;
        user.Inn = updateUserDto.Inn ?? user.Inn;
    }

    public Guid LogIn(string login, string password)
    {
        if (!_usersByLogin.TryGetValue(login, out var userId))
            throw new Exception("User not found.");
        var user = GetUser(userId);
        if (!user.HasPassword(password))
            throw new Exception("Invalid password.");
        return userId;
    }
}