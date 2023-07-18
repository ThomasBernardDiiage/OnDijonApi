namespace OnDijon.Models.Responses.Shelter;

public class CreateShelterReportResponse
{
    public int Id { get; set; }
    public int ShelterId { get; set; }
    public string Date { get; set; }
    public string Object { get; set; } // Title
    public string Comment { get; set; } // Text
}