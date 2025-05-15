namespace App.Practice4;

public sealed class Customer : User
{
    public Customer() {}
    public Customer(string login, string passwordHash,
        string name, string surname,
        string inn, string phone) : base(login, passwordHash, name, surname, inn, phone)
    {
    }
    public Cart Cart { get; set; }
    public List<Order> Orders { get; set; } = new();
}