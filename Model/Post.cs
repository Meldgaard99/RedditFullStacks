using System.ComponentModel.DataAnnotations.Schema;


namespace RedditFullStack.models

{
    [Table("Post")]
    public class Post
    {
        public string Title { get; set; }

        public int PostId { get; set; }
                //public EF kræver en id til at identificere primary keys! :)

        public string User { get; set; }
        public string Text { get; set; }
        public int NumberOfVotes { get; set; }
    

    public Post(string title, string user, string text, int NumberOfVotes ){

        this.Title = title;
        this.User = user;
        this.Text = text;
        this.NumberOfVotes = NumberOfVotes;
     

    }
    }
}