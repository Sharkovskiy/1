using Microsoft.AspNetCore.Mvc;
using WebApplication10.Models;
using WebApplication10.Controllers;

namespace WebApplication10.Controllers
{
    [Route("/api/[controller]")]
    public class GoodsController : Controller
    {
        private readonly GoodsContext db;
        public GoodsController(GoodsContext db) {
            this.db = db;
            db.Goods.Add(new Good() { title = "ssss", price = 12, sizes = { "small", "big" }, description = "sss" });
        }



        [HttpGet]
        public IEnumerable<Good> GetGoods() {
            return db.Goods;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }




}
