namespace RecipeManagement.IntegrationTests.FeatureTests.Recipe;

using RecipeManagement.SharedTestHelpers.Fakes.Recipe;
using RecipeManagement.IntegrationTests.TestUtilities;
using RecipeManagement.Dtos.Recipe;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using RecipeManagement.Domain.Recipes.Features;
using static TestFixture;

public class UpdateRecipeCommandTests : TestBase
{
    [Test]
    public async Task can_update_existing_recipe_in_db()
    {
        // Arrange
        var fakeRecipeOne = FakeRecipe.Generate(new FakeRecipeForCreationDto().Generate());
        var updatedRecipeDto = new FakeRecipeForUpdateDto().Generate();
        await InsertAsync(fakeRecipeOne);

        var recipe = await ExecuteDbContextAsync(db => db.Recipes.SingleOrDefaultAsync());
        var id = recipe.Id;

        // Act
        var command = new UpdateRecipe.UpdateRecipeCommand(id, updatedRecipeDto);
        await SendAsync(command);
        var updatedRecipe = await ExecuteDbContextAsync(db => db.Recipes.Where(r => r.Id == id).SingleOrDefaultAsync());

        // Assert
        updatedRecipe.Should().BeEquivalentTo(updatedRecipeDto, options =>
            options.ExcludingMissingMembers());
    }
}