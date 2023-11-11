namespace RecipeBoxBE.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FirebaseUid { get; set; }
        public List<Recipe> FavoriteRecipes { get; } = new List<Recipe>();
        public ICollection<Recipe> Recipes { get; set; }
    }
}
