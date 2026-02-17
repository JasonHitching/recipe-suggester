using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RecipeSuggester.Api.Models;

namespace RecipeSuggester.Api.Data;

/// <summary>
/// Context used to represent a session with the database
/// </summary>
public class RecipeContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }
    // public DbSet<Ingredient> Ingredients { get; set; }

    public string DbPath { get; }

    public RecipeContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "recipes.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseSqlite($"Data source={DbPath}")
            .UseSeeding((context, _) =>
            {
                context.Set<Recipe>().AddRange
                (
                    new Recipe
                    {
                        Id = 1,
                        Name = "Spaghetti Bolognese",
                        Description = "Classic Italian pasta with rich meat sauce.",
                        RecipeId = 1001,
                        PreparationTime = 15,
                        CookingTime = 45,
                        Servings = 4,
                        Difficulty = "Medium"
                    },
                    new Recipe
                    {
                        Id = 2,
                        Name = "Chicken Caesar Salad",
                        Description = "Grilled chicken breast served on romaine lettuce with Caesar dressing.",
                        RecipeId = 1002,
                        PreparationTime = 10,
                        CookingTime = 15,
                        Servings = 2,
                        Difficulty = "Easy"
                    },
                    new Recipe
                    {
                        Id = 3,
                        Name = "Vegetable Stir Fry",
                        Description = "Mixed vegetables stir-fried in a savory sauce.",
                        RecipeId = 1003,
                        PreparationTime = 10,
                        CookingTime = 10,
                        Servings = 3,
                        Difficulty = "Easy"
                    },
                    new Recipe
                    {
                        Id = 4,
                        Name = "Beef Wellington",
                        Description = "Tenderloin steak coated with pâté and duxelles, wrapped in puff pastry.",
                        RecipeId = 1004,
                        PreparationTime = 30,
                        CookingTime = 60,
                        Servings = 4,
                        Difficulty = "Hard"
                    },
                    new Recipe
                    {
                        Id = 5,
                        Name = "Pancakes",
                        Description = "Fluffy pancakes perfect for breakfast.",
                        RecipeId = 1005,
                        PreparationTime = 5,
                        CookingTime = 10,
                        Servings = 4,
                        Difficulty = "Easy"
                    }
                );
                context.SaveChanges();
            })
            .UseAsyncSeeding(async (context, _, cancellationToken) =>
            {
                await context.Set<Recipe>().AddRangeAsync
                (
                    new Recipe
                    {
                        Id = 1,
                        Name = "Spaghetti Bolognese",
                        Description = "Classic Italian pasta with rich meat sauce.",
                        RecipeId = 1001,
                        PreparationTime = 15,
                        CookingTime = 45,
                        Servings = 4,
                        Difficulty = "Medium"
                    },
                    new Recipe
                    {
                        Id = 2,
                        Name = "Chicken Caesar Salad",
                        Description = "Grilled chicken breast served on romaine lettuce with Caesar dressing.",
                        RecipeId = 1002,
                        PreparationTime = 10,
                        CookingTime = 15,
                        Servings = 2,
                        Difficulty = "Easy"
                    },
                    new Recipe
                    {
                        Id = 3,
                        Name = "Vegetable Stir Fry",
                        Description = "Mixed vegetables stir-fried in a savory sauce.",
                        RecipeId = 1003,
                        PreparationTime = 10,
                        CookingTime = 10,
                        Servings = 3,
                        Difficulty = "Easy"
                    },
                    new Recipe
                    {
                        Id = 4,
                        Name = "Beef Wellington",
                        Description = "Tenderloin steak coated with pâté and duxelles, wrapped in puff pastry.",
                        RecipeId = 1004,
                        PreparationTime = 30,
                        CookingTime = 60,
                        Servings = 4,
                        Difficulty = "Hard"
                    },
                    new Recipe
                    {
                        Id = 5,
                        Name = "Pancakes",
                        Description = "Fluffy pancakes perfect for breakfast.",
                        RecipeId = 1005,
                        PreparationTime = 5,
                        CookingTime = 10,
                        Servings = 4,
                        Difficulty = "Easy"
                    }
                );
                await context.SaveChangesAsync(cancellationToken);
            });
}