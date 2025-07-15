using System.ComponentModel.DataAnnotations;
using Library.Entities;

namespace Library.Models.Books;

public class CreateBookRequestModel
{
    [Required]
    [MinLength(3)]
    public required string Name { get; set; }
    public required int AuthorId { get; set; }
    public BookGenre BookGenre { get; set; }
    public DateOnly? ReleaseDate { get; set; }
}