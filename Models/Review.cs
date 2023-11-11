namespace RecipeBoxBE.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewString { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
    }
}
