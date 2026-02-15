using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.AI;
using OllamaSharp;

namespace RecipeSuggester.Api.Controllers;

/// <summary>
/// For basic crud
/// </summary>
[ApiController]
[Route("[controller]")]
public class RecipesController(IChatClient ollamaChatClient, ILogger<RecipesController> logger) : ControllerBase
{
    private readonly IChatClient _ollamaChatClient = ollamaChatClient;
    private readonly ILogger<RecipesController> _logger = logger;

    [HttpGet]
    [Route("/test")]
    public async Task<string> TestAPIChatResponse()
    {
        var modelResponse = await _ollamaChatClient.GetResponseAsync("What is the meaning of life?");

        return modelResponse.ToString();
    }

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