using System; 
namespace RedditFullStack.models
{
    public class Comment
    {
        public string Text { get; set; }
        public int CommentId { get; set; }
        //public EF kræver en id til at identificere primary keys! :)
        public int Downvote { get; set; }
        public int Upvote { get; set; }
        public int NumberOfVotes { get; set; }
        public string NewComment {get; set;}
    

    public Comment( string text, int Downvote, int Upvote, int NumberOfVotes, string NewComment){

        this.Text = text; 
        this.Downvote = Downvote; 
        this.Upvote = Upvote;
        this.NumberOfVotes = NumberOfVotes;
        this.NewComment = NewComment;



    }
    }
}