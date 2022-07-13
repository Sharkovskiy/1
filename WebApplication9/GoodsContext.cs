using Microsoft.EntityFrameworkCore;
using WebApplication9;

namespace WebApplication9
{
    public class GoodsContext : DbContext
    {
        public DbSet<GoodsStructure> Goods { get; set; }
        public GoodsContext(DbContextOptions<GoodsContext> options) :
            base(options)
        {
            Database.EnsureCreated();
        }
        
    }
}
