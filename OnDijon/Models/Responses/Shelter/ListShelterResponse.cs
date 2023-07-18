using System;
namespace OnDijon.Models.Responses.Shelter;

public class ListShelterResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int Capacity { get; set; }
    public int Occupation { get; set; }
}

