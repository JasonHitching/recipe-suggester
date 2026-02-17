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

            var finalPrompt = $"Give me a recommended recipe from these recipes {recipes} which best fits with these ingredients: ({parsedIngredients})";

            var promptResponse = await _ollamaChatClient.GetResponseAsync(finalPrompt);

            return promptResponse.ToString();

        }
        catch (Exception ex)
        {
            _logger.LogError("Error occured whilst making chat client request {error}", ex);
        }

        return "";
    }
}
