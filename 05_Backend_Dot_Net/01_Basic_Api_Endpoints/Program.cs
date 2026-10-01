var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () => "Hello World!");
app.MapGet("/downloads", () => "Downloads page");
app.MapPost("/submit", () => "Submit page");
app.MapPut("/update", () => "Update page");
app.MapDelete("/delete", () => "Delete page");


app.Run();
