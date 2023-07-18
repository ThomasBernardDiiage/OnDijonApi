using System;
namespace OnDijon.Models.Responses.Address;

public class CreateAddressResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string UserId { get; set; }
    public string Phone { get; set; }
}