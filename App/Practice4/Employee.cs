namespace App.Practice4;

public sealed class Employee : User
{
    public Employee() {}
    public Employee(string login, string passwordHash,
        string name, string surname,
        string inn, string phone) : base(login, passwordHash, name, surname, inn, phone)
    {
    }
    
    public string Inn { get; set; }
    public List<Order> Orders { get; set; } = new();
}