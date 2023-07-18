using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace OnDijon.Models.Responses.Itinerary
{
    public class GeoveloResponseItem
    {
        [JsonPropertyName("sections")]
		public IEnumerable<GeoveloSection> Sections { get; set; }
        [JsonPropertyName("distances")]
        public GeoveloDistances Distances { get; set; }
        [JsonPropertyName("waypoints")]
        public IEnumerable<GeoveloWaypoint> Waypoints { get; set; }
        public string Title { get; set; }
        [JsonPropertyName("estimatedDatetimeOfDeparture")]
        public string EstimatedDatetimeOfDeparture { get; set; }
        [JsonPropertyName("estimatedDatetimeOfArrival")]
        public string EstimatedDatetimeOfArrival { get; set; }
        [JsonPropertyName("duration")]
        public int Duration { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }


        //"title": "RECOMMENDED",
        //"estimatedDatetimeOfDeparture": "2023-05-16T10:46:19.734230",
        //"estimatedDatetimeOfArrival": "2023-05-16T11:05:13.734230",
        //"duration": 1134,
        //"id": "bG9jPTQ4Ljg0MTAyLDIuMzIwMzc4JmxvYz00OC44NTgyMTQsMi4yOTI1MTYjTUVESUFOI0ZhbHNlI01FRElBTiMxNSNGYWxzZSNOb25lIzIwMjMtMDUtMTYgMTA6NDY6MTkuNzM0MjMwI1RSQURJVElPTkFMIzAjMCNSRUNPTU1FTkRFRCNUcnVlI0ZhbHNl"
        //"distances":
        //  {
        //    "total": 3348,
        //	  "normalRoads": 77,
        //	  "recommendedRoads": 1534,
        //	  "discouragedRoads": 1737
        //  },
        //"waypoints":
        //[
        //  {
        //	  "longitude": 2.3203780,
        //	  "latitude": 48.8410200,
        //	  "title": "Gare Montparnasse"
        //	},
        //	{
        //    "longitude": 2.2925160,
        //	  "latitude": 48.8582140,
        //	  "title": "Tour Eiffel"
        //  }
        //],

    }

    public class GeoveloSection
    {
        [JsonPropertyName("duration")]
        public int Duration { get; set; }
        [JsonPropertyName("waypoints")]
        public IEnumerable<GeoveloWaypoint> Waypoints { get; set; }
        [JsonPropertyName("estimatedDatetimeOfDeparture")]
        public string EstimatedDatetimeOfDeparture { get; set; }
        [JsonPropertyName("estimatedDatetimeOfArrival")]
        public string EstimatedDatetimeOfArrival { get; set; }
        /// <summary>
        /// Encoded array
        /// </summary>
        [JsonPropertyName("geometry")]
        public string Geometry { get; set; }
        [JsonPropertyName("waypointIndices")]
        public IEnumerable<int> WaypointIndices { get; set; }
        [JsonPropertyName("transportMode")]
        public string TransportMode { get; set; }
        [JsonPropertyName("details")]
        public GeoveloSectionDetails Details { get; set; }

        //"sections":
        //[
        //	{
        //		"transportMode": "BIKE",
        //		"duration": 1134,
        //		"waypointsIndices": null,
        //		"geometry": null,
        //		"estimatedDatetimeOfDeparture": "2023-05-16T10:46:19.734230",
        //		"estimatedDatetimeOfArrival": "2023-05-16T11:05:13.734230",
        //		"details": {
        //			"distances": {
        //				"total": 3348,
        //				"normalRoads": 77,
        //				"recommendedRoads": 1534,
        //				"discouragedRoads": 1737,
        //				"cycleway": 504,
        //				"greenway": 0,
        //				"lane": 29,
        //				"livingstreet": 0,
        //				"sharebusway": 533,
        //				"footway": 248,
        //				"pedestrian": 220,
        //				"opposite": 0,
        //				"steps": 0,
        //				"zone30": 0,
        //				"residential": 77
        //          },
        //			"instructions": [
        //              [
        //					"direction",
        //					"roadName",
        //					"roadLength",
        //					"facility",
        //					"cyclability",
        //					"geometryIndex",
        //					"orientation",
        //					"cityNames",
        //					"duration"
        //				],
        //				[
        //					"HEAD_ON",
        //					"voie piétonne",
        //					18,
        //					"FOOTWAY",
        //					4,
        //					0,
        //					"SW",
        //					"",
        //					16
        //				],
        //				[
        //					"TURN_RIGHT",
        //					"voie piétonne",
        //					21,
        //					"FOOTWAY",
        //					4,
        //					4,
        //					"NW",
        //					"",
        //					19
        //				],
        //				[
        //					"REACHED_YOUR_DESTINATION",
        //					"",
        //					0,
        //					"NONE",
        //					3,
        //					176,
        //					"N",
        //					"",
        //					0
        //				]
        //			],
        //			"profile": "MEDIAN",
        //			"direction": "Boulevard Pasteur, Avenue de Suffren",
        //			"verticalGain": 30,
        //			"verticalLoss": 58,
        //			"calories": 101858,
        //			"elevations": null,
        //			"ridesets": [],
        //			"averageSpeed": 15,
        //			"bikeType": "TRADITIONAL"
        //		},
        //		"waypoints": [
        //			{
        //				"longitude": 2.3203780,
        //				"latitude": 48.8410200,
        //				"title": "Gare Montparnasse"
        //			},
        //			{
        //              "longitude": 2.2925160,
        //				"latitude": 48.8582140,
        //				"title": "Tour Eiffel"
        //          }
        //		]
        //	}
        //],


    }

    public class GeoveloDistances
    {
        [JsonPropertyName("normalRoads")]
        public int NormalRoads { get; set; }
        [JsonPropertyName("recommendedRoads")]
        public int RecommendedRoads { get; set; }
        [JsonPropertyName("discouragedRoads")]
        public int DiscouragedRoads { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }

    public class GeoveloWaypoint
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public class GeoveloSectionDetails
    {
        [JsonPropertyName("profile")]
        public string? Profile { get; set; }
        [JsonPropertyName("distances")]
        public GeoveloDistances Distances { get; set; }
        [JsonPropertyName("electric_adapted_itinerary")]
        public bool? Electric_adapted_itinerary { get; set; }
        [JsonPropertyName("averageSpeed")]
        public double AverageSpeed { get; set; }
        [JsonPropertyName("direction")]
        public string Direction { get; set; }
        [JsonPropertyName("verticalGain")]
        public double VerticalGain { get; set; }
        [JsonPropertyName("bikeType")]
        public string? BikeType { get; set; }
        /// <summary>
        /// All contents can be string or number due to first enumerable being all string, but second, third, etc. containing numbers too.
        /// </summary>
        [JsonPropertyName("instructions")]
        public IEnumerable<IEnumerable<object>> Instructions { get; set; }
        [JsonPropertyName("elevations")]
        public IEnumerable<object> Elevations { get; set; }
        [JsonPropertyName("stepIndices")]
        public IEnumerable<int> StepIndices { get; set; }
        [JsonPropertyName("bikeStations")]
        public object? BikeStations { get; set; }
    }
}
