namespace OnDijon.Domain
{
    public class User : BaseEntity
    {
        public string Guid { get; set; }
        public int? Age { get; set; }
        public int? MeanOfLocomotionId { get; set; }
        public int? ReasonForTravelId { get; set; }
    }
}