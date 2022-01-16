namespace RecipeManagement.Seeders.DummyData;

using AutoBogus;
using RecipeManagement.Domain.Recipes;
using RecipeManagement.Dtos.Recipe;
using RecipeManagement.Databases;
using System.Linq;

public static class RecipeSeeder
{
    public static void SeedSampleRecipeData(RecipesDbContext context)
    {
        if (!context.Recipes.Any())
        {
            context.Recipes.Add(Recipe.Create(new AutoFaker<RecipeForCreationDto>()));
            context.Recipes.Add(Recipe.Create(new AutoFaker<RecipeForCreationDto>()));
            context.Recipes.Add(Recipe.Create(new AutoFaker<RecipeForCreationDto>()));

            context.SaveChanges();
        }
    }
}