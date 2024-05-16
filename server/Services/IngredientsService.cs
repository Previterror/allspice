

namespace allspice.Services;

public class IngredientsService
{
    private readonly IngredientsRepository _repository;
    private readonly RecipesService _recipesService;

    public IngredientsService(IngredientsRepository repository, RecipesService recipesService)
    {
        _repository = repository;
        _recipesService = recipesService;
    }

    internal Ingredient AddIngredient(string userId, Ingredient ingredientData)
    {
        Recipe recipe = _recipesService.GetRecipeById(ingredientData.RecipeId);
        if (userId != recipe.CreatorId)
        {
            throw new Exception("You are not authorized to add ingredients to this recipe.");
        }
        Ingredient ingredient = _repository.AddIngredient(ingredientData);
        return ingredient;
    }

    internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
    {
        List<Ingredient> ingredients = _repository.GetIngredientsByRecipe(recipeId);
        return ingredients;
    }

    internal string RemoveIngredient(string userId, int ingredientId)
    {
        Ingredient ingredient = _repository.GetIngredientById(ingredientId);
        Recipe recipe = _recipesService.GetRecipeById(ingredient.RecipeId);
        if (userId != recipe.CreatorId)
        {
            throw new Exception("You are not authorized to remove ingredients from this recipe.");
        }

        _repository.RemoveIngredient(ingredient.id);
        return $"{ingredient.Name} has been removed from {recipe.Title}.";
    }
}