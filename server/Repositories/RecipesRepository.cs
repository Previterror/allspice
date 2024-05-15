




namespace allspice.Repositories;

public class RecipesRepository
{
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
        _db = db;
    }

    private Recipe PopulateCreator(Recipe recipe, Profile profile)
    {
        recipe.Creator = profile;
        return recipe;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        string sql = @"
        INSERT INTO
        recipes(title, instructions, img, category, creatorId)
        VALUES(@Title, @Instructions, @Img, @Category, @CreatorId);

        SELECT
        recipes.*,
        accounts.*
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id
        WHERE recipes.id = LAST_INSERT_ID();";

        Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, PopulateCreator, recipeData).FirstOrDefault();
        return recipe;
    }

    internal List<Recipe> GetAllRecipes()
    {
        string sql = @"
        SELECT
        recipes.*,
        accounts.*
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id;";

        List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(sql, PopulateCreator).ToList();
        return recipes;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        string sql = @"
        SELECT
        recipes.*,
        recipes.*
        FROM
        recipes
        JOIN accounts ON accounts.id = recipes.creatorId
        WHERE recipes.id = @recipeId;";

        Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, PopulateCreator, new { recipeId }).FirstOrDefault();
        return recipe;
    }

    internal Recipe UpdateRecipe(Recipe recipeToUpdate)
    {
        string sql = @"
        UPDATE recipes
        SET
        title = @Title,
        instructions = @Instructions,
        img = @img,
        category = @category
        WHERE id = @Id;

        SELECT
        recipes.*,
        accounts.*
        FROM recipes
        JOIN accounts ON accounts.id = recipes.creatorId
        WHERE recipes.id = @Id;";

        Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, PopulateCreator, recipeToUpdate).FirstOrDefault();
        return recipe;
    }

    internal void RemoveRecipe(int recipeId)
    {
        string sql = " DELETE FROM recipes WHERE id = @recipeId;";
        _db.Execute(sql, new { recipeId });
    }
}