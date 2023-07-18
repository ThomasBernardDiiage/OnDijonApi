namespace OnDijon.Models.Responses.Itinerary
{
    public class GetItineraryResponse
    {

        public int EstimatedTime { get; set; }

		public List<string> Pathing { get; set; } = new List<string>();

		public List<ItineraryResponseDirection> Directions { get; set; } = new List<ItineraryResponseDirection>();

    }

    public class ItineraryResponseDirection
    {
        public string Instruction { get; set; } = "UNKNOWN";
		public string AreaName { get; set; } = "Unknown";
        public int Distance { get; set; }
		public string Orientation { get; set; } = "Unknown";

            
							//"direction",
							//"HEAD_ON",

							//"roadName",
							//"voie piétonne",
			
							//"roadLength",
							//18,
							
							//"facility",
							//"FOOTWAY",
							
							//"cyclability",
							//4,
							
							//"geometryIndex",
							//0,
							
							//"orientation",
							//"SW",
							
							//"cityNames",
							//"",
							
							//"duration"
							//16
    }
}
