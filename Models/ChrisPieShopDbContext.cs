using Microsoft.EntityFrameworkCore;

namespace ChrisPieShop.Models
{
    public class ChrisPieShopDbContext : DbContext
    {
        public ChrisPieShopDbContext(DbContextOptions<ChrisPieShopDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }
    }
}
