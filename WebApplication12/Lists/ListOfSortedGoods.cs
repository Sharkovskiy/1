using WebApplication12.Models;
namespace WebApplication12.Lists
{
    public class ListOfSortedGoods
    {
        private static readonly List<Product> sort = new List<Product>();

        public List<Product> GetListOfSortedGoods() {
            return sort;
        }

        public void SortSizeAndMaxPrice(String size, int maxprice, List<GoodStructure> goodsList, String highlight)
        {
            //if (size?.Length >= 0 && maxprice > 0)
            //{
            //    for (int i = 0; i < goodsList[0].Products.Length; i++)
            //    {
            //        for (int j = 0; j < goodsList[0].Products[i].Sizes.Length; i++)
            //        {
            //            if (goodsList[0].Products[i].Price <= maxprice && goodsList[0].Products[i].Sizes[j] == size)
            //            {
            //                sort.Add(goodsList[0].Products[i]);
            //            }
            //        }
            //    }
            //}
            //if (size?.Length >= 0 && maxprice == 0)
            //{
            //    for (int i = 0; i < goodsList[0].Products.Length; i++)
            //    {
            //        for (int j = 0; j < goodsList[0].Products[i].Sizes.Length; i++)
            //        {
            //            if (goodsList[0].Products[i].Sizes[j] == size)
            //            {
            //                sort.Add(goodsList[0].Products[i]);
            //            }
            //        }
            //    }
            //}
            //if (size?.Length == null && maxprice > 0)
            //{
            //    for (int i = 0; i < goodsList[0].Products.Length; i++)
            //    {
            //        if (goodsList[0].Products[i].Price <= maxprice)
            //        {
            //            sort.Add(goodsList[0].Products[i]);
            //        }
            //    }
            //}
            //if (highlight != null) {
            //    for (int i = 0; i < goodsList[0].Products.Length; i++)
            //    {
            //        sort.Add(new Product { Title = goodsList[0].Products[i].Title,
            //            Price = goodsList[0].Products[i].Price,
            //            Sizes = goodsList[0].Products[i].Sizes,
            //            Description = goodsList[0].Products[i].Description.Replace(highlight, "<em>" + highlight + "</em>")});
            //    }
            //}

            var sorted = from goods in goodsList[0].Products
                         select goods;

            //if (size.Length >= 0 && maxprice == 0){
            //    for (int i = 0; i < goodsList[0].Products.Length; i++)
            //    {
            //        for (int j = 0; j < goodsList[0].Products[i].Sizes.Length; i++)
            //        {
            //            if (goodsList[0].Products[i].Sizes[j] == size)
            //            {
            //                sorted = sorted.Where(x => x.Sizes[j] == size);
            //            }
            //        }
            //    }
            //}




            if (size == null && maxprice != 0) { 
            sorted = sorted.Where(x => x.Price <= maxprice);
            }

            foreach (var good in sorted)
            {
                if (highlight != null)
                {
                    sort.Add(new Product
                    {
                        Title = good.Title,
                        Price = good.Price,
                        Sizes = good.Sizes,
                        Description = good.Description.Replace(highlight, "<em>" + highlight + "</em>")
                    });
                }
                else {
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
