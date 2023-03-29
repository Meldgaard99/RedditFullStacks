using System.ComponentModel.DataAnnotations.Schema;


namespace RedditFullStack.models

{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
        public int Downvote { get; set; }
        public int Upvote { get; set; }
        public int NumberOfVotes { get; set; }
    

    public Post(string title, string user, string text, int Downvotes, int Upvotes, int NumberOfVotes ){

        this.Title = title;
        this.User = user;
        this.Text = text;
        this.Upvotes = upvotes;
        this.Downvotes = downvotes;
        this.NumberOfVotes = numberOfVotes;
     

    }
    }
}