namespace OnDijon.Models.Requests.Itinerary
{
    public class GeoVeloRequest
    {
        public IEnumerable<Waypoint> Waypoints { get; set; } = new List<Waypoint>();
    }

    public class Waypoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Title { get; set; }
    }
}
