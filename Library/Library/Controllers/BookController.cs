using Library.DataBase;
using Library.Entities;
using Library.Models.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers;

[ApiController]
[Route("/books")]
public class BookController(LibraryDbContext dbContext) : ControllerBase
{
    public IActionResult GetAllBooks()
    {
        return Ok(dbContext.Books.ToList());
    }
    [HttpGet("{bookId:int}")]
    public IActionResult GetBookById(int bookId)
    {
        var book = dbContext.Books.Find(bookId);
        
        if(book is null) return NotFound();
        
        return Ok(book);
    }

    [HttpPost]
    public IActionResult CreateBook([FromBody] CreateBookRequestModel model)
    {
        var currentDate = DateOnly.FromDateTime(DateTime.Now);
        
        if(model.ReleaseDate is not null && model.ReleaseDate > currentDate) return BadRequest("ReleaseDate must be before current day");
        var newBook = new Book
        {
            Name = model.Name,
            AuthorId = model.AuthorId,
            BookGenre = model.BookGenre,
            ReleaseDate = model.ReleaseDate,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow            
        };
        dbContext.Books.Add(newBook);
        dbContext.SaveChanges();

        return Ok(newBook);
    }

    [HttpPut("{bookId:int}")]
    public IActionResult UpdateBook(int bookId, [FromBody] UpdateBookRequestModel model)
    {
        var book = dbContext.Books.Find(bookId);
        if(book is null) return NotFound();

        var currentDate = DateOnly.FromDateTime(DateTime.Now);
        
        if (!string.IsNullOrWhiteSpace(model.Name))
            book.Name = model.Name;

        if (model.AuthorId.HasValue)
            book.AuthorId = model.AuthorId.Value;

        if (model.BookGenre.HasValue)
            book.BookGenre = model.BookGenre.Value;

        if (model.ReleaseDate.HasValue)
            book.ReleaseDate = model.ReleaseDate;
        
        book.UpdatedAt = DateTime.Now;

        dbContext.SaveChanges();

        return Ok();
    }

    [HttpDelete("{bookId:int}")]
    public IActionResult DeleteBook(int bookId)
    {        
        var book = dbContext.Books.Find(bookId);
        if (book is null)
            return NotFound("Book not found");

        dbContext.Books.Remove(book);
        dbContext.SaveChanges();

        Console.WriteLine("Book deleted");
        return NoContent();
    }
}