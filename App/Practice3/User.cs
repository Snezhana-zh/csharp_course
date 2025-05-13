namespace App.Practice3;
using System.Text.RegularExpressions;

public class User
{
    private readonly Guid _id;
    private readonly string _login;
    private string _passwordHash;
    private string _name;
    private string _surname;
    private readonly string _inn;
    private string _phone;
    private readonly DateTime _registerDate;
    
    private static readonly Regex PhoneRegex =
        new Regex(@"(8|\+7|7)+[\s-\(]*(9\d{2})[\s-\)]*\d{3}[\s-]*\d{2}[\s-]*\d{2}", RegexOptions.Compiled);
    
    public Guid Id { get => _id; init => _id = value; }
    public string Login { get => _login; init => _login = value; }
    public string PasswordHash { get => _passwordHash; set => _passwordHash = value; }
    public string Name { get => _name; set => _name = value; }
    public string Surname { get => _surname; set => _surname = value; }
    public string Inn { get => _inn; init => _inn = value; }
    public DateTime RegisterDate { get => _registerDate; init => _registerDate = value; }

    public string Phone
    {
        get => _phone;
        set => TryUpdatePhone(value);
    }
    public User()
    {
        _id = Guid.NewGuid();
        _registerDate = DateTime.Now;
    }
    public User(string login, string passwordHash, string name, string surname, string inn, string phone) : this()
    {
        _login = login;
        _passwordHash = passwordHash;
        _name = name;
        _surname = surname;
        _inn = inn;
        Phone = phone;
    }
    public string GetUserFullName()
    {
        return _name + " " + _surname;
    }
    private static bool TryParsePhone(string inputString, out string parsedPhone) 
    {
        parsedPhone = null;
        var match = PhoneRegex.Match(inputString);
        if (!match.Success) return false;
        
        var digits = new String(match.Value.Where(char.IsDigit).ToArray());

        if (digits.Length == 11)
        {
            if (digits[0] == '7' && digits[1] == '9') parsedPhone = '+' + digits;
            else if (digits[0] == '8' && digits[1] == '9') parsedPhone = "+7" + digits.Substring(1);
            return parsedPhone != null;
        }
        return false;
    }
    private bool TryUpdatePhone(string phone)
    {
        var isValidPhone =  TryParsePhone(phone, out string validPhone);
        if (!isValidPhone) return false;
        _phone = validPhone;
        return true;
    }
}