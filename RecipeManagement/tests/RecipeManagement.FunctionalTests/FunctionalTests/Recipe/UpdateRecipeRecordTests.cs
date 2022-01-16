namespace RecipeManagement.FunctionalTests.FunctionalTests.Recipe;

using RecipeManagement.SharedTestHelpers.Fakes.Recipe;
using RecipeManagement.FunctionalTests.TestUtilities;
using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

public class UpdateRecipeRecordTests : TestBase
{
    [Test]
    public async Task put_recipe_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var fakeRecipe = FakeRecipe.Generate(new FakeRecipeForCreationDto().Generate());
        var updatedRecipeDto = new FakeRecipeForUpdateDto { }.Generate();
        await InsertAsync(fakeRecipe);

        // Act
        var route = ApiRoutes.Recipes.Put.Replace(ApiRoutes.Recipes.Id, fakeRecipe.Id.ToString());
        var result = await _client.PutJsonRequestAsync(route, updatedRecipeDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}