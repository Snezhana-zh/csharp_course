namespace App.Practice3;
using System.Text.RegularExpressions;

public class User
{
    private readonly Guid _id;
    private readonly string _login;
    private string _password;
    private string _name;
    private string _surname;
    private readonly string _inn;
    private string _phone;
    private readonly DateTime _registerDate;
    
    private static readonly Regex PhoneRegex =
        new Regex(@"(8|\+7|7)+[\s-\(]*(9\d{2})[\s-\)]*\d{3}[\s-]*\d{2}[\s-]*\d{2}", RegexOptions.Compiled);

    public User(string login, string password, string name, string surname, string inn, string phone)
    {
        _registerDate = DateTime.Now;
        _login = login;
        _password = password;
        _name = name;
        _surname = surname;
        _inn = inn;
        _phone = phone;
        _id = Guid.NewGuid();
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
    public bool TryUpdatePhone(string phone)
    {
        var isValidPhone =  TryParsePhone(phone, out string validPhone);
        if (!isValidPhone) return false;
        _phone = validPhone;
        return true;
    }
}