namespace RecipeManagement.Dtos.Recipe;

using RecipeManagement.Dtos.Shared;

public class RecipeParametersDto : BasePaginationParameters
{
    public string Filters { get; set; }
    public string SortOrder { get; set; }
}