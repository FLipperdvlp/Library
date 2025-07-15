using Library.DataBase;
using Library.Entities;
using Library.Models.Authors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers;

[ApiController]
[Route("/authors")]
public class AuthorController(LibraryDbContext dbContext) : ControllerBase
{
    public IActionResult GetAllAuthors()
    {
        return Ok(dbContext.Authors.ToList());
    }

    [HttpGet("{authorId:int}")]
    public IActionResult GetAuthorById(int authorId)
    {
        var author = dbContext.Authors.Find(authorId);
        
        if(author is null) return NotFound();
        
        return Ok(author);
    }

    [HttpPost]
    public IActionResult CreateAuthor([FromBody] CreateAuthorRequestModel model)
    {
        var currentDate = DateOnly.FromDateTime(DateTime.Now);

        if (model.DeathDate is not null && model.DeathDate > currentDate)
        { 
            return BadRequest("Death date must be less than current date");
        }

        var newAuthor = new Author
        {
            Name = model.Name,
            DeathDate = model.DeathDate,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        dbContext.Authors.Add(newAuthor);
        dbContext.SaveChanges();

        return Ok(newAuthor);
    }
    
    
    [HttpPut("{authorId:int}")]
    public IActionResult UpdateAuthor(int authorId, [FromBody] UpdateAuthorRequestModel model)
    {
        var author = dbContext.Authors.Find(authorId);
        if (author is null)
            return NotFound("Author not found");

        var currentDate = DateOnly.FromDateTime(DateTime.Now);

        if (model.DeathDate is not null && model.DeathDate > currentDate)
            return BadRequest("Death date must be less than current date");

        if (model.Name is not null && model.Name.Length >= 3)
            author.Name = model.Name;

        if (model.DeathDate.HasValue)
            author.DeathDate = model.DeathDate;

        author.UpdatedAt = DateTime.Now;

        dbContext.SaveChanges();

        return Ok(author);
    }
    
    
    [HttpDelete("{authorId:int}")]
    public IActionResult DeleteAuthor(int authorId)
    {
        var author = dbContext.Authors.Include(a => a.Books).FirstOrDefault(a => a.Id == authorId);
        if (author is null)
            return NotFound("Author not found");
        
        dbContext.Books.RemoveRange(author.Books); 
        dbContext.Authors.Remove(author);
        dbContext.SaveChanges();

        return NoContent(); 
    }

    
    [HttpGet("{authorId:int}/books")]
    public IActionResult GetAuthorBooks(int authorId)
    {
        var author = dbContext.Authors.Include((a => a.Books)).FirstOrDefault(a => a.Id == authorId);
        
        if(author is null)
            return NotFound("Author not found");
        return Ok(author.Books);
    }
}