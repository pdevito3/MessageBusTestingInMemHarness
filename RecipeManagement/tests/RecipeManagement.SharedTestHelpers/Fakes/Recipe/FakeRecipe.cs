namespace RecipeManagement.SharedTestHelpers.Fakes.Recipe;

using AutoBogus;
using RecipeManagement.Domain.Recipes;
using RecipeManagement.Dtos.Recipe;

public class FakeRecipe
{
    public static Recipe Generate(RecipeForCreationDto recipeForCreationDto)
    {
        return Recipe.Create(recipeForCreationDto);
    }
}