using System.Security.Cryptography.X509Certificates;

namespace RecipeBoxBE.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Directions { get; set; }
        public string CookTime { get; set; }
        public string Ingredients { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
