using System; 
namespace RedditFullStack.models
{
    public class Comment
    {
        public string Text { get; set; }

        public int CommentId { get; set; }
        //public EF kræver en id til at identificere primary keys! :)
        public int NumberOfVotes { get; set; }
        public int Downvote { get; set; }
        public int Upvote { get; set; }
        public string NewComment {get; set;}
    

    public Comment( string text, int NumberOfVotes, int Downvote, int Upvote, string NewComment){

        this.Text = text; 
       this.NumberOfVotes = NumberOfVotes;
        this.Downvote = Downvote; 
        this.Upvote = Upvote;
        this.NewComment = NewComment;



    }
    }
}