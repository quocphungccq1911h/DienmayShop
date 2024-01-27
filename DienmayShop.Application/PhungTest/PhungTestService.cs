using DienmayShop.Data.EF;
using DienmayShop.Utilities.Extensions;
using DienmayShop.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace DienmayShop.Application.PhungTest
{
    public class PhungTestService : IPhungTestService
    {
        private readonly DienmayShopDbContext _context;
        private readonly IDistributedCache _cache;
        private readonly string _PhungTestRedis = "PhungTestRedis";
        public PhungTestService(DienmayShopDbContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<List<PhungTestVM>> GetAll()
        {
            var list = new List<PhungTestVM>();
            byte[]? phungTestListByArray;

            phungTestListByArray = await _cache.GetAsync(_PhungTestRedis);
            if(phungTestListByArray != null && phungTestListByArray.Length > 0)
            {
                list = ConvertData<PhungTestVM>.ByteArrayToObjectList(phungTestListByArray);
            }
            else
            {
                list =  await _context.PhungTests.Select(x => new PhungTestVM()
                {
                    Name = x.Name,
                }).ToListAsync();
                phungTestListByArray = ConvertData<PhungTestVM>.ObjectListToByteArray(list);
                await _cache.SetAsync(_PhungTestRedis, phungTestListByArray);
            }
            return list;
        }
        public async Task<int> Create(PhungTestVM requestVM)
        {
            var phungTest = new Data.Entities.PhungTest()
            {
                Name = requestVM.Name,
            };
            _context.PhungTests.Add(phungTest);
            await _context.SaveChangesAsync();
            return phungTest.Id;
        }
    }
}
