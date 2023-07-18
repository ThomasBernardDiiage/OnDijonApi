using System;
namespace OnDijon.Models.Responses.Shelter;

public class GetShelterByIdHistoryResponse
{
    public string Date { get; set; }
    public bool IsEntry { get; set; }
    public int Spot { get; set; }
}
