namespace RecipeSuggester.Api.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int RecipeId { get; set; }
    public int PreparationTime { get; set; }
    public int CookingTime { get; set; }
    public int Servings {  get; set; }
    public string Difficulty { get; set; } = default!;

    public override string ToString()
    {
        return $"{Name}: {Description} (Prep: {PreparationTime} min, Cook: {CookingTime} min, Servings: {Servings}, Difficulty: {Difficulty})";
    }
}
