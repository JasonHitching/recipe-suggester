using Microsoft.EntityFrameworkCore;
using RecipeSuggester.Api.Data;
using RecipeSuggester.Api.Models;

namespace RecipeSuggester.Api.Respositories;

public class RecipeRepository : IRecipeRepository
{
    private readonly RecipeContext _recipeContext;

    public RecipeRepository(RecipeContext recipeContext)
    {
        _recipeContext = recipeContext;
    }

    public async Task<List<Recipe>> GetAllRecipes()
    {
        var allRecipes = await _recipeContext.Recipes.ToListAsync();

        return allRecipes;
    }
}
