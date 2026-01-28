using System;

namespace MoneyFlow.Entities;

public class Service
{
    public int ServiceId { get; set; }
    public int UserId { get; set; }
    public String Name { get; set; }
    public String Type { get; set; }

    public User user { get; set; }
    


}
