namespace ChrisPieShop.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategory { get; }
    }
}
