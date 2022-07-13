using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

using WebApplication12.Models;


namespace WebApplication12.Controllers
{
    [Route("/api/[controller]")]
    public class GoodsController : Controller
    {
        static readonly List<GoodStructure> goods = new List<GoodStructure>();
        static readonly List<Product> sort = new List<Product>();

        public void AddToList() {
            var list = JsonConvert.DeserializeObject<GoodStructure>(new WebClient().DownloadString("http://www.mocky.io/v2/5e307edf3200005d00858b49"));
            goods.Add(new GoodStructure() { Products = list.Products, ApiKeys = list.ApiKeys });
        }

       
        public GoodsController()
        {
            AddToList();
        }

        public int FindMin(List<Product> products) {
            int min = int.MaxValue;
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Price < min) { 
                    min = products[i].Price;
                }
            }
            return min;
        }

        public int FindMax(List<Product> products)
        {
            int max = int.MinValue;
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Price > max)
                {
                    max = products[i].Price;
                }
            }
            return max;
        }

        public void SortSizeAndMaxPrice(String size, int maxprice, List<GoodStructure> goodsList) {
            if (size?.Length >= 0 && maxprice > 0)
            {
                for (int i = 0; i < goodsList[0].Products.Length; i++)
                {
                    for (int j = 0; j < goodsList[0].Products[i].Sizes.Length; i++)
                    {
                        if (goodsList[0].Products[i].Price <= maxprice && goodsList[0].Products[i].Sizes[j] == size)
                        {
                            sort.Add(goodsList[0].Products[i]);
                        }
                    }
                }
                Console.WriteLine("Filtered maxprice + size : " + sort.Count);
            }
        }

        public void SortSize(String size, int maxprice, List<GoodStructure> goodsList)
        {
            if (size?.Length >= 0 && maxprice == 0)
            {
                for (int i = 0; i < goodsList[0].Products.Length; i++)
                {
                    for (int j = 0; j < goodsList[0].Products[i].Sizes.Length; i++)
                    {
                        if (goodsList[0].Products[i].Sizes[j] == size)
                        {
                            sort.Add(goodsList[0].Products[i]);
                        }
                    }
                }
                Console.WriteLine("Filtered size : " + sort.Count);
            }
        }

        public void SortMaxPrice(String size, int maxprice, List<GoodStructure> goodsList)
        {
            if (size?.Length == null && maxprice > 0)
            {
                for (int i = 0; i < goodsList[0].Products.Length; i++)
                {
                    if (goodsList[0].Products[i].Price <= maxprice)
                    {
                        sort.Add(goodsList[0].Products[i]);
                    }
                }
                Console.WriteLine("Filtered maxprice : " + sort.Count);
            }
        }

        [HttpGet]
        public String GetGood() {
            Console.WriteLine("Not filtered : " + goods[0].Products.Length);
            return JsonConvert.SerializeObject(goods[0].Products);
        }
        
        [HttpGet("filter")]
        public String GetGood(String? size, int maxprice) {
            if (sort is not null)
            {
                sort.Clear();
            }
            SortSizeAndMaxPrice(size, maxprice, goods);
            SortSize(size, maxprice, goods);
            SortMaxPrice(size, maxprice, goods);
            
            return JsonConvert.SerializeObject(sort) + "\nMinimum price of products : " + FindMin(sort) + "\nMaximum price of products : " + FindMax(sort);
        }

        [HttpGet("{id}")]
        public String GetGoods(int index) {
            try
            {
                return JsonConvert.SerializeObject(goods[0].Products[index]); ;
            }
            catch (IndexOutOfRangeException) {
                return default;}
        }
    }
}




