namespace RecipeManagement.FunctionalTests.FunctionalTests.Recipe;

using RecipeManagement.SharedTestHelpers.Fakes.Recipe;
using RecipeManagement.FunctionalTests.TestUtilities;
using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

public class CreateRecipeTests : TestBase
{
    [Test]
    public async Task create_recipe_returns_created_using_valid_dto()
    {
        // Arrange
        var fakeRecipe = new FakeRecipeForCreationDto { }.Generate();

        // Act
        var route = ApiRoutes.Recipes.Create;
        var result = await _client.PostJsonRequestAsync(route, fakeRecipe);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}