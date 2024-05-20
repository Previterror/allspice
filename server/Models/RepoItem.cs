namespace allspice.Models;

public abstract class RepoItem<T>
{
    public T id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}