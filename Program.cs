using System.Text.Json.Serialization;
using RecipeBoxBE.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<RecipeBoxDbContext>(builder.Configuration["RecipeBoxDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000",
                                "http://localhost:7007")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowAnyOrigin();
        });
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Create User
app.MapPost("/register", (RecipeBoxDbContext db, User user) =>
{
    db.Users.Add(user);
    db.SaveChanges();
    return Results.Created($"/user/user.Id", user);
});

//Check if the user is in the database
app.MapGet("/checkuser/{uid}", (RecipeBoxDbContext db, string uid) =>
{
    var user = db.Users.Where(x => x.FirebaseUid == uid).ToList();
    if (uid == null)
    {
        return Results.NotFound();
    }
    else
    {
        return Results.Ok(user);
    }
});

//Get all users
app.MapGet("/user", (RecipeBoxDbContext db) =>
{
    return db.Users.ToList();
});

//Get users by ID
app.MapGet("/user/{id}", (RecipeBoxDbContext db, int id) =>
{
    var user = db.Users.Where(u => u.Id == id);
    return user;
});

//Get all recipes
app.MapGet("/recipes", (RecipeBoxDbContext db) =>
{
    return db.Recipes.ToList();
});

//Get a single recipe
app.MapGet("/recipe/{id}", (RecipeBoxDbContext db, int id) =>
{
    var recipes = db.Recipes.SingleOrDefault(x => x.Id == id);
    return recipes;
});

//Create a recipe
app.MapPost("/recipes", (RecipeBoxDbContext db, Recipe recipe) =>
{
    db.Recipes.Add(recipe);
    db.SaveChanges();
    return Results.Created($"/recipes/{recipe.Id}", recipe);
});

//Delete a recipe
app.MapDelete("/recipes/{id}", (RecipeBoxDbContext db, int id) =>
{
    Recipe recipe = db.Recipes.SingleOrDefault(r => r.Id == id);
    if (recipe == null)
    {
        return Results.NotFound();
    }
    db.Recipes.Remove(recipe);
    db.SaveChanges();
    return Results.NoContent();
});

//Update a recipe
app.MapPut("/recipes", (RecipeBoxDbContext db, int id, Recipe recipe) =>
{
    Recipe recipeToUpdate = db.Recipes.SingleOrDefault(recipe => recipe.Id == id);
    if (recipeToUpdate == null)
    {
        return Results.NotFound();
    }
    recipeToUpdate.Name = recipe.Name;
    recipeToUpdate.Ingredients = recipe.Ingredients;
    recipeToUpdate.CategoryId = recipe.CategoryId;
    recipeToUpdate.CookTime = recipe.CookTime;
    recipeToUpdate.Directions = recipe.Directions;
    recipeToUpdate.ImgUrl = recipe.ImgUrl;

    db.SaveChanges();
    return Results.NoContent();
});

//Get all categories
app.MapGet("/category", (RecipeBoxDbContext db) =>
{
    return db.Categories.ToList();
});

//View recipes by Category
app.MapGet("recipes/category/{category}", (RecipeBoxDbContext db, int categoryId) =>
{
    var category = db.Categories.Find(categoryId);
    if (category == null)
    {
        return Results.NotFound();
    }
    var recipes = db.Recipes.Where(r => r.CategoryId == categoryId);
    return Results.Ok(recipes);
});

//Get a user's favorite recipes
app.MapGet("/recipes/favorites/{userId}", (RecipeBoxDbContext db, int userId) =>
{
    var user = db.Users.Include(u => u.FavoriteRecipes).FirstOrDefault(x => x.Id == userId);
    if (user == null)
    {
        return Results.NotFound();
    }
    var favoriteRecipes = user.FavoriteRecipes.ToList();
    return Results.Ok(favoriteRecipes);
});

//Add to user's favorite recipes list
app.MapPost("/recipes/addtofavorites", async (RecipeBoxDbContext db, int recipeId, int userId) =>
{
    var user = await db.Users
    .Include(u => u.FavoriteRecipes)
    .FirstOrDefaultAsync(x => x.Id == userId);

    if (user == null)
    {
        return Results.NotFound();
    }
    var recipe = await db.Recipes.FindAsync(recipeId);
    if (recipe == null)
    {
        return Results.NotFound("Recipe not found.");
    }
    var existingRecipe = user.FavoriteRecipes.FirstOrDefault(r => r.Id == recipeId);
    if (existingRecipe != null)
    {
        return Results.BadRequest("Recipe already exists in user's favorites.");
    }
    user.FavoriteRecipes.Add(recipe);
    await db.SaveChangesAsync();
    return Results.Ok("Recipe added successfully!");
});

//Get all reviews
app.MapGet("/reviews", (RecipeBoxDbContext db) =>
{
    return db.Reviews.ToList();
});

//Get reviews by Recipe 
app.MapGet("/recipes/{recipeId}/reviews", (RecipeBoxDbContext db, int recipeId) =>
{
    var recipe = db.Recipes.Include(r => r.Reviews).FirstOrDefault(r => r.Id == recipeId);
    if (recipe == null)
    {
        return Results.NotFound();
    }
    var reviews = recipe.Reviews.ToList();
    return Results.Ok(reviews);
});

app.MapPost("/reviews", (RecipeBoxDbContext db, Review review) =>
{
    db.Reviews.Add(review);
    db.SaveChanges();
    return Results.Created("reviews/{reviewId}", review);
});

app.MapDelete("/reviews/{reviewId}", (RecipeBoxDbContext db, int reviewId) =>
{
    Review review = db.Reviews.FirstOrDefault(r => r.Id == reviewId);
    db.Reviews.Remove(review);
    db.SaveChanges();
    return Results.NoContent();
});

app.MapPut("/reviews/{reviewId}", (RecipeBoxDbContext db, int reviewId) =>
{
    Review reviewToUpdate = db.Reviews.FirstOrDefault(r => r.Id == reviewId);
    if (reviewToUpdate == null)
    {
        return Results.NotFound();
    }
    reviewToUpdate.ReviewString = reviewToUpdate.ReviewString;
    db.SaveChanges();
    return Results.NoContent();
});

app.Run();
