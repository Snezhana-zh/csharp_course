namespace App.Practice3;
using System.Text.RegularExpressions;

public class User
{
    private readonly Guid id;
    private readonly string login;
    private string passwordHash;
    private string name;
    private string surname;
    private readonly string inn;
    private string phone;
    private DateTime registerDate;
    
    public Guid Id { get => id; init => id = value; }
    public string Login { get => login; init => login = value; }
    public string PasswordHash { get => passwordHash; set => passwordHash = value; }
    public string Name { get => name; set => name = value; }
    public string Surname { get => surname; set => surname = value; }
    public string Inn { get => inn; init => inn = value; }
    public DateTime RegisterDate { get => registerDate; init => registerDate = value; }

    public string Phone
    {
        get => phone;
        set
        {
            if (!TryUpdatePhone(value)) throw new ArgumentException("Invalid phone number");
        }
    }
    public User()
    {
        id = Guid.NewGuid();
        registerDate = DateTime.Now;
    }
    public User(string login, string passwordHash, string name, string surname, string inn, string phone) : this()
    {
        this.login = login;
        this.passwordHash = passwordHash;
        this.name = name;
        this.surname = surname;
        this.inn = inn;
        _ =  TryParsePhone(phone, out this.phone);
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

    private bool TryUpdatePhone(string phone)
    {
        var isValidPhone =  TryParsePhone(phone, out string validPhone);
        if (!isValidPhone) return false;
        this.phone = validPhone;
        return true;
    }
}