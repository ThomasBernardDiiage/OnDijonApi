using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace OnDijon.Models.Requests.Shelter;

public class CreateShelterReportRequest
{
    [Required]
    public string? Object { get; set; } 
    
    [Required]
    public string? Comment { get; set; } 
    
    [Required]
    public string? UserId { get; set; } 
}