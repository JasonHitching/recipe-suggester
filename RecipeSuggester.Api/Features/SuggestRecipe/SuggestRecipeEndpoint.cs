using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.AI;

namespace RecipeSuggester.Api.Features.SuggestRecipe;

[Controller]
[Route("[controller]")]
public class SuggestRecipeEndpoint : ControllerBase
{
    private readonly IChatClient _ollamaChatClient;
    private readonly ILogger<SuggestRecipeEndpoint> _logger;
    private readonly SuggestRecipeHandler _handler;

    public SuggestRecipeEndpoint(IChatClient ollamaChatClient, ILogger<SuggestRecipeEndpoint> logger, SuggestRecipeHandler handler)
    {
        _ollamaChatClient = ollamaChatClient;
        _logger = logger;
        _handler = handler;
    }

    [HttpPost]
    [Route("/recipes/suggestion")]
    public async Task<string> GenerateRecipeSuggestion([FromBody] SuggestRecipeRequest recipeRequest)
    {
        try
        {
            _logger.LogInformation("Making a request to ollama with the following prompt: {prompt}", recipeRequest);

            var recipes = await _handler.GetAllRecipes();

            var parsedIngredients = String.Join(", ", recipeRequest.Ingredients);

            var finalPrompt = BuildPrompt(parsedIngredients, recipes.RecipeResponse);

            var promptResponse = await _ollamaChatClient.GetResponseAsync(finalPrompt);

            return promptResponse.ToString();

        }
        catch (Exception ex)
        {
            _logger.LogError("Error occured whilst making chat client request {error}", ex);
        }

        return "";
    }

    private string BuildPrompt(string parsedIngredients, string recipes)
    {
        var systemPrompt = @"You are a recipe matching assistant. Your task is to analyze recipes and match them to available ingredients.

            Matching criteria:
            1. Count how many of the user's ingredients appear in each recipe
            2. Prioritize recipes where the user has ALL or MOST of the key ingredients
            3. Consider which recipe needs the fewest additional ingredients

            Output format: Return the most appropriate recipe, also highlight any potential extra ingredients that may be required to make the full dish.

            General remarks: This is a personal prompt, refer to people in first person. No use of terms like; user etc";

        var userPrompt = $@"Available ingredients: {parsedIngredients}

            Recipes to consider:
            {recipes}

            Which single recipe best matches the available ingredients?";

        return $"{systemPrompt}\n\n{userPrompt}";
    }
}
