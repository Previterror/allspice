namespace allspice.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]

public class IngredientsController : ControllerBase
{
    private readonly IngredientsService _ingredientsService;

    private readonly Auth0Provider _auth0Provider;
    public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth0Provider)
    {
        _ingredientsService = ingredientsService;
        _auth0Provider = auth0Provider;
    }

    [HttpPost]
    public async Task<ActionResult<Ingredient>> AddIngredient([FromBody] Ingredient ingredientData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            Ingredient ingredient = _ingredientsService.AddIngredient(userInfo.Id, ingredientData);
            return ingredient;
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpDelete("{ingredientId}")]
    public async Task<ActionResult<string>> RemoveIngredient(int ingredientId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string message = _ingredientsService.RemoveIngredient(userInfo.Id, ingredientId);
            return message;
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

}