
using RedditFullStack_main.model;
using Model;
using RedditFullStack.models;
using System.Collections.Generic;
using System.Linq;

public class DataService
{
    
    private TaskContext db { get; }

    public DataService(TaskContext db) {
        this.db = db;
    }



 public List<TodoTask> GetAllTask()
    {
        return db.Tasks.ToList();
    }


    //henter post og returner dem som en liste
    public List<Post> GetAllPosts()
    {
        return db.Posts.ToList();
    }




    public Post GetPostById(int postid)
    {
        return db.Posts.Where(p => p.PostId == postid).FirstOrDefault()!;
        

    }

  public Comment GetCommentById(int commentid)
    {
        return db.Comments.Where(p => p.CommentId == commentid).FirstOrDefault()!;
        

    }




/*
    public List<User> GetAllUsers()
    {
        return db.Users.ToList();
    }

//henter post og returner dem som en liste
    public List<Post> GetPosts()
    {
        return db.Posts.ToList();
    }
*/





//Test med at lave en post
//logiken er den 
/* public Post CreatePost(string Title, string User, string Text, int NumberOfVotes)
{
    if (!db.Users.Any(u => u.Name == User))
    {
        User newuser = new User(User);
        db.Add(newuser);
        db.SaveChanges();
    }
    
//Mangler at lave en return af en post 

     
    }
  
}
*/
}
