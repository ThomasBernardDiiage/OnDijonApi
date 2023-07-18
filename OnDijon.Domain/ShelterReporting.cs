namespace OnDijon.Domain;

public class ShelterReporting : BaseEntity
{
    public int ShelterId { get; set; }
    public DateTimeOffset Date { get; set; }
    public string Object { get; set; } // Title
    public string Comment { get; set; } // Text
    public int UserId { get; set; } // Creator of report
}