namespace RecipeManagement.Domain.Recipes;

using RecipeManagement.Dtos.Recipe;
using RecipeManagement.Domain.Recipes.Mappings;
using RecipeManagement.Domain.Recipes.Validators;
using AutoMapper;
using FluentValidation;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Sieve.Attributes;


public class Recipe : BaseEntity
{
    [Sieve(CanFilter = true, CanSort = true)]
    public string Title { get; private set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public string Directions { get; private set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public string RecipeSourceLink { get; private set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public string Description { get; private set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public string ImageLink { get; private set; }


    public static Recipe Create(RecipeForCreationDto recipeForCreationDto)
    {
        new RecipeForCreationDtoValidator().ValidateAndThrow(recipeForCreationDto);
        var mapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.AddProfile<RecipeProfile>();
        }));
        var newRecipe = mapper.Map<Recipe>(recipeForCreationDto);
        
        return newRecipe;
    }
        
    public void Update(RecipeForUpdateDto recipeForUpdateDto)
    {
        new RecipeForUpdateDtoValidator().ValidateAndThrow(recipeForUpdateDto);
        var mapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.AddProfile<RecipeProfile>();
        }));
        mapper.Map(recipeForUpdateDto, this);
    }
    
    private Recipe() { } // For EF
}