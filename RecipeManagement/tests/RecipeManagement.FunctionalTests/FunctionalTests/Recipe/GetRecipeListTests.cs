namespace RecipeManagement.FunctionalTests.FunctionalTests.Recipe;

using RecipeManagement.SharedTestHelpers.Fakes.Recipe;
using RecipeManagement.FunctionalTests.TestUtilities;
using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

public class GetRecipeListTests : TestBase
{
    [Test]
    public async Task get_recipe_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await _client.GetRequestAsync(ApiRoutes.Recipes.GetList);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}