using Microsoft.EntityFrameworkCore;
using WebApplication7.Models;

namespace WebApplication7.Repositories
{
    public class GoodsRepository : IGoodsRepository
    {
        private readonly GoodsContext _context;

        public GoodsRepository(GoodsContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<GoodsStructure>> Get(){
            return await _context.Goods.ToListAsync();
        }

        public async Task<GoodsStructure> Get(int id) {
            return await _context.Goods.FindAsync(id);
        }

        public async Task<GoodsStructure> Create(GoodsStructure goodsStructure) {
             _context.Goods.Add(goodsStructure);
            await _context.SaveChangesAsync();
            return goodsStructure;
        }

        
    }
}
