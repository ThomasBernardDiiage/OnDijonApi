using System;
namespace OnDijon.Domain;

public class Shelter : BaseEntity
{
	public string Name { get; set; } = string.Empty;
	public double Latitude { get; set; }
	public double Longitude { get; set; }
	public int Capacity { get; set; }
}