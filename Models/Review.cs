namespace RecipeBoxBE.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewString { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public string photoUrl { get; set; }
        public string userName { get; set; }
    }
}
