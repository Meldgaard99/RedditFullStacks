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
    //db.Add(new TodoTask("tester",false));
    //db.Add(new Post("Titel","Rasmus", "test text", 5)); //Test om der er hul til post tablen!
    db.Add(new User( "Mads"));
    db.SaveChanges();



    }

// Henter alle tasks
app.MapGet("/get/all/tasks", (DataService service) =>
{
    return service.GetAllTask();
});

// Henter post på dets id
app.MapGet("/get/post/{postid}", (DataService service, int postid) =>
{
    return service.GetPostById(postid);  
});

// Henter alle kommentarer
app.MapGet("/get/all/comments", (DataService service) =>
{
    return service.GetAllComments();
});

// Henter en kommmentar på dets id
app.MapGet("/get/comment/{commentid}", (DataService service, int commentid) =>
{
    return service.GetCommentById(commentid);  
});

// Henter user på bruger id
app.MapGet("/get/user/{userid}", (DataService service, int userid) =>
{
    return service.GetUserById(userid);  
});

// Henter alle brugere
app.MapGet("/get/all/users", (DataService service) =>
{
    return service.GetAllUsers();
});


/*
Ikke færdig mangler at finde den rigtig syntax 
app.MapGet("/getallpostbyid", (DataService service, long postid) =>
{
    return service.GetPostById();  
});
*/


//Rasmus get calls 
/*
//Hent user 
app.MapGet("/getallusers", ) =>
{
});

//Hent post id
app.MapGet("/getpost/{id}", ) =>
{
    return service.GetPost(id);
});

//Hent user id
app.MapGet("/getuser/{id}", () =>
{
    return service.GetUser(id);
});
app.MapGet("/getallcomment/{id}"

*/

// Read
    Console.WriteLine("Find det sidste task");
    

//app.MapGet("/", () => "Hello World!");


app.Run();



/*
app.MapPost("/createpost", (DataService service, PostDTO data) =>
 {
     return service.CreatePost(data.title, data.user, data.text, data.NumberOfVotes);
 });



app.Run();
 record PostDTO(string title, string user, string text,  int NumberOfVotes);
 */

