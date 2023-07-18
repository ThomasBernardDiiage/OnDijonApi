namespace OnDijon.Models.Responses.Shelter;

public class CreateShelterBookResponse
{
    public int Id { get; set; }
    public int ShelterId { get; set; }
    public string UserId { get; set; }
    public string Date { get; set; }
    public string BeginDate { get; set; }
    public string EndDate { get; set; }
}