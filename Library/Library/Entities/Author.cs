using System.Text.Json.Serialization;

namespace Library.Entities;

public class Author : BaseEntity
{
    public  required  string      Name        { get; set; }
    public            DateOnly?   DeathDate   { get; set; }
    [JsonIgnore]
    public            List<Book>  Books       { get; set; } = [];
}