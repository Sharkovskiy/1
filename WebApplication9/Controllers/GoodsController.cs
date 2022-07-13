using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication9.Models;
using WebApplication9;
using System.Net;
using Newtonsoft.Json;

namespace WebApplication9.Controllers
{
    [ApiController]
    [Route("api")]
    public class GoodsController : Controller
    {
        private readonly ILogger<GoodsController> _logger;
        GoodsContext db;
        public GoodsController(ILogger<GoodsController> logger,GoodsContext options)
        {
            _logger = logger;
            db = options;
            Uri uri = new Uri("http://www.mocky.io/v2/5e307edf3200005d00858b49");
            String html = new WebClient().DownloadString(uri);
            var list = JsonConvert.DeserializeObject<GoodsStructure>(html);
            db.Add(list);
            db.SaveChanges();

        }
        //[HttpGet]
        //public async Task<IEnumerable<GoodsStructure>> GetGoods()
        //{

        //}

    }
}