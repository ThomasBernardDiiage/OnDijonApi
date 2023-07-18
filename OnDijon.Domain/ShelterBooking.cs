namespace OnDijon.Domain;

public class ShelterBooking : BaseEntity
{
    public int Id { get; set; }
    public int? ShelterId { get; set; }
    public string UserId { get; set; }
    public DateTimeOffset Date { get; set; }
    public DateTimeOffset BeginDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
}