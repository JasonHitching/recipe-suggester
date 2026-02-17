using Microsoft.EntityFrameworkCore;
using RecipeSuggester.Api.Data;
using RecipeSuggester.Api.Models;
using System.Text;

namespace RecipeSuggester.Api.Features.SuggestRecipe;

/// <summary>
/// TODO: Handle db query? passing request to a service to handle the AI prompt?
/// </summary>
public class SuggestRecipeHandler(RecipeContext recipeContext)
{
    private readonly RecipeContext _recipeContext = recipeContext;


    public async Task<string> GetAllRecipes()
    {
        var allRecipes = await _recipeContext.Recipes.ToListAsync();

        
        return string.Join("\n", allRecipes.Select(r => r.ToString()));
    }
}
