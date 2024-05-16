
namespace allspice.Repositories;

public class FavoritesRepository
{
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal FavRec AddFavorite(Favorite favoriteData)
    {
        string sql = @"
        INSERT INTO
        favorites(recipeId, accountId)
        VALUES (@RecipeId, @AccountId);

        SELECT
        favorites.*,
        recipes.*,
        accounts.*
        FROM favorites
        JOIN recipes ON recipes.id = favorites.recipeId
        JOIN accounts on accounts.id = favorites.accountId
        WHERE favorites.id = LAST_INSERT_ID();";

        FavRec favorite = _db.Query<Favorite, FavRec, Profile, FavRec>(sql, (favorite, recipe, profile) =>
        {
            recipe.FavoriteId = favorite.id;
            recipe.Creator = profile;

            return recipe;
        }, favoriteData).FirstOrDefault();
        return favorite;
    }
}