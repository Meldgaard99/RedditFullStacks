using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

using Model;
using RedditFullStack_main.model;
using RedditFullStack.models;

var builder = WebApplication.CreateBuilder(args);

// Sætter CORS så API'en kan bruges fra andre domæner
var AllowSomeStuff = "_AllowSomeStuff";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSomeStuff, builder => {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});





// Tilføj DbContext factory som service.
builder.Services.AddDbContext<TaskContext>(options =>
  options.UseSqlite(builder.Configuration.GetConnectionString("ContextSQLite")));


// Tilføj DataService så den kan bruges i endpoints
builder.Services.AddScoped<DataService>();



var app = builder.Build();


app.UseHttpsRedirection();
app.UseCors(AllowSomeStuff);

using (var db = new TaskContext())
{
    Console.WriteLine($"Database path: {db.DbPath}.");
    
    // Create
    Console.WriteLine("Submitting data to DB");
    db.Add(new TodoTask("tester",false));
    db.Add(new Post("Titel","Rasmus", "test text", 5)); //Test om der er hul til post tablen!
    db.SaveChanges();



    }




app.MapGet("/get", (DataService service) =>
{
    return service.GetAllTask();
});


app.MapGet("/", () => "Hello World!");

app.Run();



/*
app.MapPost("/createpost", (DataService service, PostDTO data) =>
 {
     return service.CreatePost(data.title, data.user, data.text, data.NumberOfVotes);
 });



app.Run();
 record PostDTO(string title, string user, string text,  int NumberOfVotes);
 */

