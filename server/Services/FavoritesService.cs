
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
}