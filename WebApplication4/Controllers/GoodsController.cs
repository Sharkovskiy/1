using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FiveTask1.Models;
using FiveTask1;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace FiveTask1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        GoodsContext db;
        public GoodsController(GoodsContext context)
        {
            db = context;
            if (!db.Goods.Any())
            {
                var list = JsonConvert.DeserializeObject<GoodsStructure>(new WebClient().DownloadString(new Uri("http://www.mocky.io/v2/5e307edf3200005d00858b49")));


                db.Goods.Add(new GoodsStructure { products = list.products, apikeys = list.apikeys  } ) ;
                db.SaveChanges();
            }
            
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoodsStructure>>> Get()
        {
            return await db.Goods.ToListAsync();
        }
        /* [HttpGet("{id}")]
         public async Task<ActionResult<GoodsStructure>> Get(int price) {
             for (int i = 0; i < list.products.Length; i++)
             {
             Product ProductStructure = await db.Goods.FirstOrDefaultAsync(x => x.products[].price == price);
         }*/

       /* [HttpPost]
        public async Task<ActionResult<GoodsStructure>> Post(GoodsStructure goodsStructure)
        {
            if (goodsStructure == null)
            {
                return BadRequest();
            }

            db.Goods.Add(goodsStructure);
            await db.SaveChangesAsync();
            return Ok(goodsStructure);
        }*/
    }
}

