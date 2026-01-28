using System;

namespace MoneyFlow.Entities;

public class User
{
    public int UserId  { get; set; }
    public string FullName  { get; set; }
    public string Email  { get; set; }
    public string Password  { get; set; }
    public ICollection<Service> Services  { get; set; }

    public ICollection<Transaction> Transactions  { get; set; }
}
