using System;
using System.ComponentModel.DataAnnotations;

namespace OnDijon.Models.Requests.ShelterHistory;

public class CreateShelterHistoryRequest
{
    [Required]
    public bool? IsEntry { get; set; } = null;
    
    [Required]
    public int? Spot { get; set; }
}

