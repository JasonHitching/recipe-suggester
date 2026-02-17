using Microsoft.EntityFrameworkCore;
using RecipeSuggester.Api.Data;
using RecipeSuggester.Api.Models;
using RecipeSuggester.Api.Respositories;
using System.Text;

namespace RecipeSuggester.Api.Features.SuggestRecipe;

/// <summary>
/// TODO: Handle db query? passing request to a service to handle the AI prompt?
/// </summary>
public class SuggestRecipeHandler
{
    private readonly IRecipeRepository _recipeRepository;

    public SuggestRecipeHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    public async Task<SuggestRecipeResponse> GetAllRecipes()
    {
        var allRecipes = await _recipeRepository.GetAllRecipes();

        return new SuggestRecipeResponse { RecipeResponse = string.Join("\n", allRecipes.Select(r => r.ToString())) }; 
    }
}
