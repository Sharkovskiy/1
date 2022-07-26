using WebApplication12.Models;
namespace WebApplication12.Lists
{
    public class ListOfSortedGoods
    {
        private static readonly List<Product> sort = new List<Product>();

        public List<Product> GetListOfSortedGoods()
        {
            return sort;
        }

        public void Sorting(String size, int maxprice, List<GoodStructure> goodsList, String[] highlight)
        {
                var sorted = from goods in goodsList[0].Products
                             from sizes in goods.Sizes
                             where (goods.Price <= maxprice && size == null) ||
                             (goods.Price <= maxprice && sizes == size) ||
                             (maxprice == 0 && sizes == size)
                             select goods;

            foreach (var good in sorted)
            {
                if (highlight.Length == 1)
                {
                    sort.Add(new Product
                    {
                        Title = good.Title,
                        Price = good.Price,
                        Sizes = good.Sizes,
                        Description = good.Description.Replace(highlight[0], "<em>" + highlight[0] + "</em>")
                    });
                }
                if (highlight.Length == 2)
                {
                    sort.Add(new Product
                    {
                        Title = good.Title,
                        Price = good.Price,
                        Sizes = good.Sizes,
                        Description = good.Description.Replace(highlight[0], "<em>" + highlight[0] + "</em>")
                        .Replace(highlight[1], "<em>" + highlight[1] + "</em>")
                    });
                }
                if (highlight.Length == 0)
                {
                    sort.Add(new Product
                    {
                        Title = good.Title,
                        Price = good.Price,
                        Sizes = good.Sizes,
                        Description = good.Description
                    });
                }
            }
        }
    }
}
