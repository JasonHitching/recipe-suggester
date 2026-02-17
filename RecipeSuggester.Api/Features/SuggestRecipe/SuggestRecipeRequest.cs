using Microsoft.Extensions.ObjectPool;

namespace RecipeSuggester.Api.Features.SuggestRecipe;

/// <summary>
/// Required properties to make the request to the AI model
/// </summary>
public class SuggestRecipeRequest
{
    public required string[] Ingredients { get; set; }
}
