using System;
using System.ComponentModel.DataAnnotations;

namespace OnDijon.Models.Requests.Address;

public class CreateAddressRequest
{
    [Required]
    public string? Name { get; set; }

    [Required]
    public double? Latitude { get; set; }

    [Required]
    public double? Longitude { get; set; }

    public string Phone { get; set; } = string.Empty;
}

