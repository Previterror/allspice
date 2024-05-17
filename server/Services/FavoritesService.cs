


namespace allspice.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _repository;

    public FavoritesService(FavoritesRepository repository)
    {
        _repository = repository;
    }

    internal FavRec AddFavorite(Favorite favoriteData)
    {
        FavRec favorite = _repository.AddFavorite(favoriteData);
        return favorite;
    }

    internal List<FavRec> GetMyFavRecs(string userId)
    {
        List<FavRec> myFavRecs = _repository.GetMyFavRecs(userId);
        return myFavRecs;
    }

    internal string unFavorite(string userId, int favoriteId)
    {
        Favorite favorite = _repository.GetFavoriteById(favoriteId);
        if (userId != favorite.AccountId)
        {
            throw new Exception("You are not authorize to unfavorite this recipe.");
        }

        _repository.unFavorite(favorite.id);
        return "Favorite has been removed.";
    }
}