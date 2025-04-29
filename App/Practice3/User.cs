namespace App.Practice3;
using System.Text.RegularExpressions;

public class User
{
    private readonly Guid id;
    private readonly string login;
    private string password;
    private string name;
    private string surname;
    private readonly string inn;
    private string phone;
    private DateTime registerDate;

    public User(string login, string password, string name, string surname, string inn, string phone)
    {
        registerDate = DateTime.Now;
        this.login = login;
        this.password = password;
        this.name = name;
        this.surname = surname;
        this.inn = inn;
        _ =  TryParsePhone(phone, out this.phone);
        id = Guid.NewGuid();
    }
    public string GetUserFullName()
    {
        return name + " " + surname;
    }
    private static bool TryParsePhone(string inputString, out string parsedPhone)
    {
        parsedPhone = null;
        var phonePattern = @"(?<!\+)(8|\+7|7)+[\s-\(]*(9\d{2})[\s-\)]*\d{3}[\s-]*\d{2}[\s-]*\d{2}";
        var match = Regex.Match(inputString, phonePattern);
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
        this.phone = validPhone;
        return true;
    }
}