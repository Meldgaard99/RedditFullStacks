// TodoTask.cs
namespace Model
{

    //skal egentlig bare slette alt, den skal ikke bruges til noget
    public class TodoTask
    {
        public TodoTask(string text, bool done) {
            this.Text = text;
            this.Done = done;
        }
        public long TodoTaskId { get; set; }
        public string? Text { get; set; }
        public bool Done { get; set; }
    }
}