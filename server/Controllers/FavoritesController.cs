namespace allspice.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]

public class FavoritesController : ControllerBase
{
    private readonly FavoritesService _favoritesService;
    private readonly Auth0Provider _auth0Provider;

    public FavoritesController(FavoritesService favoritesService, Auth0Provider auth0Provider)
    {
        _favoritesService = favoritesService;
        _auth0Provider = auth0Provider;
    }

    [HttpPost]
    public async Task<ActionResult<FavRec>> AddFavorite([FromBody] Favorite favoriteData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            favoriteData.AccountId = userInfo.Id;
            FavRec favorite = _favoritesService.AddFavorite(favoriteData);
            return favorite;
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
}