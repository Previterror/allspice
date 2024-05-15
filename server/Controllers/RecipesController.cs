namespace allspice.Controllers;

public class RecipesController
{
    private readonly RecipesService _recipesService;
    private readonly Auth0Provider _auth0Provider;

    public RecipesController(RecipesService recipesService, Auth0Provider auth0Provider)
    {
        _recipesService = recipesService;
        _auth0Provider = auth0Provider;
    }
}