using WebApplication12.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Linq;


namespace WebApplication12.Lists
{
    public class ListOfGoods
    {
        private static readonly List<GoodStructure> goods = new List<GoodStructure>();

        public List<GoodStructure> GetListOfGoods()
        {
            return goods;
        }

        public ListOfGoods() {
            var list = JsonConvert.DeserializeObject<GoodStructure>(new WebClient().DownloadString("http://www.mocky.io/v2/5e307edf3200005d00858b49"));
            goods.Add(new GoodStructure() { Products = list.Products, ApiKeys = list.ApiKeys });
        }

    }
}
