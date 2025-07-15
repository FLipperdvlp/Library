using System.ComponentModel.DataAnnotations;

namespace Library.Models.Authors;

public class CreateAuthorRequestModel
{
    [Required]
    [MinLength(3)]
    public  required  string      Name        { get; set; }
    public            DateOnly?   DeathDate   { get; set; }
}