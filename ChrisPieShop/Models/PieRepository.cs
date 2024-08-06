using Microsoft.EntityFrameworkCore;

namespace ChrisPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly ChrisPieShopDbContext _chrisPieShopDbContext;

        public PieRepository(ChrisPieShopDbContext chrisPieShopDbContext)
        {
            _chrisPieShopDbContext = chrisPieShopDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _chrisPieShopDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _chrisPieShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int pieId)
        {
            return _chrisPieShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return _chrisPieShopDbContext.Pies.Where(p => p.Name.Contains(searchQuery));
        }
    }
}
