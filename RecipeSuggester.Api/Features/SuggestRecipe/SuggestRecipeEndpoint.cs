using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.AI;
using RecipeSuggester.Api.Controllers;

namespace RecipeSuggester.Api.Features.SuggestRecipe;

[Controller]
[Route("[controller]")]
public class SuggestRecipeEndpoint(IChatClient ollamaChatClient, ILogger<SuggestRecipeEndpoint> logger) : ControllerBase
{
    private readonly IChatClient _ollamaChatClient = ollamaChatClient;
    private readonly ILogger<SuggestRecipeEndpoint> _logger = logger;

    [HttpPost]
    public async Task<string> TestApiChatResponse2(string prompt)
    {
        try
        {
            _logger.LogInformation("Making a request to ollama with the following prompt: {prompt}", prompt);
            var promptResponse = await _ollamaChatClient.GetResponseAsync(prompt);

            return promptResponse.ToString();

        }
        catch (Exception ex)
        {
            _logger.LogError("Error occured whilst making chat client request {error}", ex);
        }

        return "";
    }
}
