using System.ComponentModel.DataAnnotations;

namespace Library.Models.Authors;

public class UpdateAuthorRequestModel 
{
    [Required]
    [MinLength(3)]
    public string? Name { get; set; }
    public DateOnly? DeathDate { get; set; }
}