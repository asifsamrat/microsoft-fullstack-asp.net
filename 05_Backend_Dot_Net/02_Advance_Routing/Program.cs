var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/users/{id:int}/posts/{postName}", (int id, string postName) =>
{
    return $"User ID: {id}, Post Name: {postName}";
});

app.MapGet("/products/{id:int:min(1):max(100)}", (int id) =>{
    return $"Product ID: {id}";
});

app.MapGet("/reports/{year?}", (int? year = 2026) =>
{
    return $"Year: {year}";
});

app.MapGet("/files/{*filePath}", (string filePath) =>
{
    return $"File Path: {filePath}";
});

app.MapGet("/search", (int? id, string? page) =>
{
    return $"Search ID: {id}, Page: {page}";
});

app.Run();
