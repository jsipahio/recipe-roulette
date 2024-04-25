namespace RecipeRoulette.Data.Models
{
    public class ForumPostModel
    {
        public int ID { get; set;}
        public string Author { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int NumReplies { get; set; }
    }
}