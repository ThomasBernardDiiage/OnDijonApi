using System;
namespace OnDijon.Models.Responses.ShelterHistory;

public class CreateShelterHistoryResponse
{
    public int Id { get; set; }
    public int ShelterId { get; set; }
    public bool IsEntry { get; set; }
    public string Date { get; set; }
    public int Spot { get; set; }
}