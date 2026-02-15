using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.AI;
using OllamaSharp;

namespace RecipeSuggester.Api.Controllers;

/// <summary>
/// For basic crud
/// </summary>
[ApiController]
[Route("[controller]")]
public class RecipesController(IChatClient ollamaChatClient) : ControllerBase
{
    private readonly IChatClient _ollamaChatClient = ollamaChatClient;

    [HttpGet]
    [Route("/test")]
    public async Task<string> TestAPIChatResponse()
    {
        var modelResponse = await _ollamaChatClient.GetResponseAsync("What is the meaning of life?");

        return modelResponse.ToString();
    }
}