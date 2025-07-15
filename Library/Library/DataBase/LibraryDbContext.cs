using Library.Entities;
using Microsoft.EntityFrameworkCore;
namespace Library.DataBase;
public class LibraryDbContext : DbContext {
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    public LibraryDbContext()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Library.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var authors = new List<Author>
        {
            new Author
            {
                Id = 1,
                Name = "John Doe",
                DeathDate = null,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
            new Author
            {
                Id = 2,
                Name = "Taras Shevchenko",
                DeathDate = new DateOnly(1861, 3 , 10),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }
        };
        var books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Name = "ASP.NET Core course",
                BookGenre = BookGenre.Horror,
                ReleaseDate = new DateOnly(1,1,1),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
            new Book
            {
                Id = 2,
                Name = "React course",
                BookGenre = BookGenre.Horror,
                AuthorId = 1,
                CreatedAt = DateTime.Now,
                ReleaseDate = new DateOnly(1861, 3 , 10),
                UpdatedAt = DateTime.Now,
            },
            new Book
            {
                Id = 3,
                Name = "Zapovit",
                BookGenre = BookGenre.Memoir,
                AuthorId = 2,
                ReleaseDate = new DateOnly(1845, 4, 3),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
        };
        modelBuilder.Entity<Author>().HasData(authors);
        modelBuilder.Entity<Book>().HasData(books);
    }
}