using Microsoft.EntityFrameworkCore;
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data source={DbPath}");
}
