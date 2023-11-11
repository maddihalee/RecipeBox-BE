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
    return Results.Created($"/user/{user.Id}", user);
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

//Create a recipe
app.MapPost("/recipes", (RecipeBoxDbContext db, Recipe recipe) =>
{
    db.Recipes.Add(recipe);
    db.SaveChanges();
    return Results.Created($"/recipes/{recipe.Id}", recipe);
});

//Delete a recipe
app.MapDelete("/recipes", (RecipeBoxDbContext db, int id) =>
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

app.Run();
