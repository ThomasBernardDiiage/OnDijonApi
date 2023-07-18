using System;
namespace OnDijon.Domain;

public class Address : BaseEntity
{
    public string Name { get; set; } = "";
    public int UserId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Phone { get; set; } = "";
}

