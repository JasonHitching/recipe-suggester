using RecipeSuggester.Api.Models;

namespace RecipeSuggester.Api.Respositories;

public interface IRecipeRepository
{
    Task<List<Recipe>> GetAllRecipes();
}
