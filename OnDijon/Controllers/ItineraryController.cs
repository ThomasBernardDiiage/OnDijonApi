using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OnDijon.DataAccess;
using OnDijon.Domain;
using OnDijon.Models.Requests.Itinerary;
using OnDijon.Models.Responses.Itinerary;
using System.Net;
using System.Text.Json;
using XAct.Library.Constants;

namespace OnDijon.Controllers
{
    [ApiController]
    [Route("Itinerary")]
    public class ItineraryController : Controller
    {
        public static string ApiKey { get; set; } = string.Empty;

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetItinerary([FromBody] ItineraryRequest location)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Api-Key", ApiKey);

            var request = new GeoVeloRequest()
            {
                Waypoints = new List<Waypoint>()
                {
                    new()
                    {
                        Latitude = location.StartLatitude,
                        Longitude = location.StartLongitude,
                        Title = "Point de départ"
                    },
                    new()
                    {
                        Latitude = location.EndLatitude,
                        Longitude = location.EndLongitude,
                        Title = "Arrivée"
                    }
                }
            };
            

            var reader = new StreamReader("fakeGeoveloResponse.json"); 
    
            var rawText = reader.ReadToEnd();
            var resp = JsonSerializer.Deserialize<IEnumerable<GeoveloResponseItem>>(rawText);
            var result = resp.First();

            var response = new GetItineraryResponse
            {
                EstimatedTime = result.Duration,
                Pathing = result.Sections.Select(s => s.Geometry).ToList()
            };

            return Ok(response);
        }
    }
}
