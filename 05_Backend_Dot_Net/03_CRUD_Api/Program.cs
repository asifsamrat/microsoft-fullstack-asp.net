var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var blogs = new List<Blog> {
    new Blog { Title = "First Blog", Content = "This is the content of the first blog." },
    new Blog { Title = "Second Blog", Content = "This is the content of the second blog." }
};

app.MapGet("/blogs", () => blogs);

app.MapGet("/blogs/{id:int}", (int id) =>
{
    Console.WriteLine($"Fetching blog with ID: {id}");
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound();
    }

    return Results.Ok(blogs[id]);
});

app.MapPost("/blogs", (Blog blog) =>
{
    Console.WriteLine($"Received new blog: Title={blog.Title}, Content={blog.Content}");
    blogs.Add(blog);
    return Results.Created($"/blogs/{blogs.Count - 1}", blog);
});

app.MapPut("/blogs/{id:int}", (int id, Blog updatedBlog) =>
{
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound();
    }

    blogs[id] = updatedBlog;
    return Results.Ok(updatedBlog);
});

app.MapDelete("/blogs/{id:int}", (int id) =>
{
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound();
    }

    var deletedBlog = blogs[id];
    blogs.RemoveAt(id);
    return Results.Ok(deletedBlog);
});


app.Run();

public class Blog
{
    public required string Title { get; set; }
    public required string Content { get; set; }
}
