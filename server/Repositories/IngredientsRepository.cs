


namespace allspice.Repositories;

public class IngredientsRepository
{
    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Ingredient AddIngredient(Ingredient ingredientData)
    {
        string sql = @"
       INSERT INTO
       ingredients(name, quantity, recipeId)
       VALUES(@Name, @Quantity, @RecipeId);

       SELECT
       *
       FROM ingredients
       WHERE ingredients.id = LAST_INSERT_ID();";

        Ingredient ingredient = _db.Query<Ingredient>(sql, ingredientData).FirstOrDefault();
        return ingredient;
    }


    internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
    {
        string sql = @"
        SELECT
        *
        FROM ingredients
        WHERE ingredients.recipeId = @recipeId
        ;";

        List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new { recipeId }).ToList();
        return ingredients;
    }
    internal Ingredient GetIngredientById(int ingredientId)
    {
        string sql = @"
        SELECT
        *
        FROM
        ingredients
        WHERE 
        ingredients.id = @ingredientId;";

        Ingredient ingredient = _db.Query<Ingredient>(sql, new { ingredientId }).FirstOrDefault();
        return ingredient;
    }

    internal void RemoveIngredient(int ingredientId)
    {
        string sql = @"DELETE FROM ingredients WHERE id = @ingredientId";
        _db.Execute(sql, new { ingredientId });
    }
}