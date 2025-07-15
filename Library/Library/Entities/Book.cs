namespace Library.Entities;

public class Book : BaseEntity
{
    public          int         AuthorId    { get; set; }
    public required string      Name        { get; set; }
    public          BookGenre   BookGenre   { get; set; }
    public          DateOnly?   ReleaseDate { get; set; }
    public          Author      Author      { get; set; } = null!;
}