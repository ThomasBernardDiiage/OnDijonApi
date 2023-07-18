namespace OnDijon.Models.Responses.User;

public class GetUserByIdResponse
{
    public int Id { get; set; }
    public string Guid { get; set; } = string.Empty;
    public int Age { get; set; }
    public int? MeanOfLocomotionId { get; set; }
    public int? ReasonForTravelId { get; set; } 
}
