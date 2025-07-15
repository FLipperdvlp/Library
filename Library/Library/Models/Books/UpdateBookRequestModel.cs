using System.ComponentModel.DataAnnotations;
using Library.Entities;

namespace Library.Models.Books;

public class UpdateBookRequestModel
{
    [Required]
    [MinLength(3)]
    public string? Name { get; set; }
    public int? AuthorId { get; set; }
    public BookGenre? BookGenre { get; set; }
    public DateOnly? ReleaseDate { get; set; }
}