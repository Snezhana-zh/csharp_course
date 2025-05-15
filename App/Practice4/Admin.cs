namespace App.Practice4;

public sealed class Admin : User
{
    public Admin() {}

    public Admin(string login, string passwordHash,
        string name, string surname,
        string inn, string phone) : base(login, passwordHash, name, surname, inn, phone)
    {
    }
    public List<Employee> Employees { get; set; } = new();
}