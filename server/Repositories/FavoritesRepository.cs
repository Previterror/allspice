


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

        FavRec favorite = _db.Query<Favorite, FavRec, Profile, FavRec>(sql, (favorite, favrec, profile) =>
        {
            favrec.FavoriteId = favorite.id;
            favrec.Creator = profile;

            return favrec;
        }, favoriteData).FirstOrDefault();
        return favorite;
    }

    internal Favorite GetFavoriteById(int favoriteId)
    {
        string sql = @"
        SELECT
        *
        FROM
        favorites
        WHERE
        favorites.id = @favoriteId;";

        Favorite favorite = _db.Query<Favorite>(sql, new { favoriteId }).FirstOrDefault();
        return favorite;
    }

    internal List<FavRec> GetMyFavRecs(string userId)
    {
        string sql = @"
        SELECT
        favorites.*,
        recipes.*,
        accounts.*
        FROM favorites
        JOIN recipes ON recipes.id = favorites.recipeId
        JOIN accounts on accounts.id = favorites.accountId
        WHERE favorites.accountId = @userId
        ;";

        List<FavRec> myFavRecs = _db.Query<Favorite, FavRec, Profile, FavRec>(sql, (favorite, favrec, profile) =>
        {
            favrec.FavoriteId = favorite.id;
            favrec.Creator = profile;
            return favrec;
        }, new { userId }).ToList();
        return myFavRecs;
    }

    internal void unFavorite(int favoriteId)
    {
        string sql = @"DELETE FROM favorites WHERE id = @favoriteId";
        _db.Execute(sql, new { favoriteId });
    }
}