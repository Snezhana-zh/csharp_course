namespace App.Practice4;

public sealed class Seller : User
{
    public Seller() {}
    public Seller(string login, string passwordHash,
        string name, string surname,
        string inn, string phone) : base(login, passwordHash, name, surname, inn, phone)
    {
    }
    public List<Order> Orders { get; set; } = new();
    public List<Product> Products { get; set; } = new();
    public string Inn { get; set; }
}