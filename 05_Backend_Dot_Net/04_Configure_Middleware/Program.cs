var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpLogging((o) =>{});
var app = builder.Build();

//app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();

app.UseHttpLogging();
app.Use(async (context, next) => {
    Console.WriteLine($"Incoming request: {context.Request.Method} {context.Request.Path}");
    await next.Invoke();
    Console.WriteLine($"Outgoing response: {context.Response.StatusCode}");
});

app.MapGet("/", () => "Hello World!");
app.MapGet("/hello", () => "Hello from the /hello endpoint!");

//app.UseEndpoints()

app.Run();
