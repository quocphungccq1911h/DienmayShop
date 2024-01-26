using DienmayShop.Data.EF;
using DienmayShop.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DienmayShop.Application.PhungTest
{
    public class PhungTestService : IPhungTestService
    {
        private readonly DienmayShopDbContext _context;
        public PhungTestService(DienmayShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<PhungTestVM>> GetAll()
        {
            var list = await _context.PhungTests.Select(x=> new PhungTestVM()
            {
                Name = x.Name,
            }).ToListAsync();
            return list;
        }
    }
}
