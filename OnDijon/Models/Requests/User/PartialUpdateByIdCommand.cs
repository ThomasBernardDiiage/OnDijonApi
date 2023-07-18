using OnDijon.Models.Attributes;

namespace OnDijon.Models.Requests.User;

public class PartialUpdateByIdCommand
{
    public int Age { get; set; }
    public int? MeanOfLocomotionId { get; set; }
    public int? ReasonForTravelId { get; set; } 
}
