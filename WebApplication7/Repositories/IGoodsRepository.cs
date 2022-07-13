using WebApplication7.Models;

namespace WebApplication7.Repositories
{
    public interface IGoodsRepository
    {
        Task<IEnumerable<GoodsStructure>> Get();
        Task<GoodsStructure> Get(int id);
        Task<GoodsStructure> Create(GoodsStructure goodsStructure);
    }
}
