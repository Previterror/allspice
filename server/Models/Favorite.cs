namespace allspice.Models;

public class Favorite : RepoItem<int>
{
    public int RecipeId { get; set; }
    public string AccountId { get; set; }
}