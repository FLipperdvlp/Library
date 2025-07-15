using Library.DataBase;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
//Register
builder.Services.AddControllers();
builder.Services.AddDbContext<LibraryDbContext>();


// Помогает нам понимать enum как рядок
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });



var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.MapControllers();//Direct requests to controllers

app.Run();                      