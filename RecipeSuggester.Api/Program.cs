using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.AI;
using OllamaSharp;
using RecipeSuggester.Api.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<RecipeContext>();

IChatClient ollamaClient = new OllamaApiClient("http://localhost:11434/", "smollm2:135m");

builder.Services.AddSingleton<IChatClient>(ollamaClient);

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
