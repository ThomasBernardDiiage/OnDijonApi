using System;
namespace OnDijon.Domain;

public class ShelterHistory : BaseEntity
{
	public int ShelterId { get; set; }
    public DateTimeOffset Date { get; set; }
	public bool IsEntry { get; set; } // True if it's an entry, else it's an out
	public int Spot { get; set; }
}
