using System;
namespace OnDijon.Models.Responses.Shelter;

public class GetShelterByIdResponse
{
    public string Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int Capacity { get; set; }
    public int Occupation { get; set; }
    public IEnumerable<GetShelterByIdHistoryResponse>? History { get; set; }
    public IEnumerable<GetShelterByIdReportResponse>? Reports { get; set; }
}