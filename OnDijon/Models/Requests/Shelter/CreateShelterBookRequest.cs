namespace OnDijon.Models.Requests.Shelter;

public class CreateShelterBookRequest
{
    public string UserId { get; set; }
    public DateTimeOffset BeginDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
}