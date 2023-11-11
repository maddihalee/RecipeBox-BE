using Microsoft.EntityFrameworkCore;
using RecipeBoxBE.Models;

public class RecipeBoxDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Recipe> Recipes { get; set; }

    public RecipeBoxDbContext(DbContextOptions<RecipeBoxDbContext> context) : base(context) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Recipe>().HasData(new Recipe[]
        {
            new Recipe { Id = 1, Name = "Peanut Butter and Jelly", Directions = "Put peanut butter on one piece of bread and jelly on the other. Combine", CookTime = "5 Minutes", Ingredients = "Peanut Butter, Jelly, 2 Slices Bread", CategoryId = 1, UserId = 1}
        });

        modelBuilder.Entity<Category>().HasData(new Category[]
        {
            new Category { Id = 1, Name = "Quick Recipes" },
            new Category { Id = 2, Name = "American" },
            new Category { Id = 3, Name = "Holiday"},
            new Category { Id = 4, Name = "Mexican"},
            new Category { Id = 5, Name = "Japanese"},
            new Category { Id = 6, Name = "Indian"},
            new Category { Id = 7, Name = "Chinese"},
            new Category { Id = 8, Name = "Breakfast"},
            new Category { Id = 9, Name = "Italian"},
            new Category { Id = 10, Name = "Korean"},
            new Category { Id = 11, Name = "Desserts"}
        });

        modelBuilder.Entity<User>().HasData(new User[]
        {
            new User { Id = 1, Name = "Madds", Email = "ThisisanEmail@email.com", FirebaseUid = "123abc"}
        });

        modelBuilder.Entity<Review>().HasData(new Review[]
        {
            new Review { Id = 1, RecipeId = 1, UserId = 1, ReviewString = "I love making this because it is so quick and easy!"}
        });

    }
}