using FiveTask1.Models;
using Newtonsoft.Json;
using System.Net;

namespace FiveTask1
{
    public class Class
    {
        GoodsContext db;

        public void GoodsBase(GoodsContext context)
        {
            db = context;
            if (!db.Goods.Any())
            {
                var list = JsonConvert.DeserializeObject<GoodsStructure>(new WebClient().DownloadString(new Uri("http://www.mocky.io/v2/5e307edf3200005d00858b49")));
                db.Goods.Add(new GoodsStructure { products = list.products, apikeys = list.apikeys });
                db.SaveChanges();
            }

        }

    }
}
