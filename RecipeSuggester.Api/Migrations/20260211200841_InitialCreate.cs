using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeSuggester.Api.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Recipes",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Name = table.Column<string>(type: "TEXT", nullable: false),
                Description = table.Column<string>(type: "TEXT", nullable: false),
                RecipeId = table.Column<int>(type: "INTEGER", nullable: false),
                PreparationTime = table.Column<int>(type: "INTEGER", nullable: false),
                CookingTime = table.Column<int>(type: "INTEGER", nullable: false),
                Servings = table.Column<int>(type: "INTEGER", nullable: false),
                Difficulty = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Recipes", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Recipes");
    }
}
