namespace ChrisPieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ChrisPieShopDbContext _chrisPieShopDbContext;

        public CategoryRepository(ChrisPieShopDbContext chrisPieShopDbContext)
        {
            _chrisPieShopDbContext = chrisPieShopDbContext;
        }

        public IEnumerable<Category> AllCategories =>
            _chrisPieShopDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
