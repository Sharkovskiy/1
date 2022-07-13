using Microsoft.EntityFrameworkCore;

namespace FiveTask1.Models
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


