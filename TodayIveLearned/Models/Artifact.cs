namespace TodayIveLearned.Models
{
    public class Artifact
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Topic Topic { get; set; }
    }
}