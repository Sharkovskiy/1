using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication12.Lists;

namespace WebApplication12.Controllers
{
    [Route("/api/[controller]")]
    public class GoodsController : Controller
    {
        private readonly ListOfGoods _listOfGoods;
        private readonly ListOfSortedGoods _listOfSortedGoods;
        private readonly Logic _logic;

        public GoodsController(ListOfGoods listOfGoods, ListOfSortedGoods listOfSortedGoods, Logic logic)
        {
            _listOfGoods = listOfGoods;
            _listOfSortedGoods = listOfSortedGoods;
            _logic = logic;
        }

        [HttpGet]
        public String GetGood()
        {
            return JsonConvert.SerializeObject(_listOfGoods.GetListOfGoods()[0].Products);
        }

        [HttpGet("filter")]
        public String GetGood(String? size, int maxprice, String[] highlight)
        {
                if (_listOfSortedGoods.GetListOfSortedGoods() is not null)
                {
                    _listOfSortedGoods.GetListOfSortedGoods().Clear();
                }
                _listOfSortedGoods.Sorting(size, maxprice, _listOfGoods.GetListOfGoods(), highlight);
                try
                {
                return JsonConvert.SerializeObject(_listOfSortedGoods.GetListOfSortedGoods()) +
                    "\nMinimum price of products : " + _listOfSortedGoods.GetListOfSortedGoods().Min(a => a.Price) +
                    "\nMaximum price of products : " + _listOfSortedGoods.GetListOfSortedGoods().Max(a => a.Price) +
                    "\nMost common words : \n" + _logic.MostCommonWords(_listOfSortedGoods.GetListOfSortedGoods()) +
                    "Size of all Products : \n" + _logic.AllSizeOfAllProducts(_listOfSortedGoods.GetListOfSortedGoods());


            }
                catch (InvalidOperationException) {
                    return JsonConvert.SerializeObject(_listOfGoods.GetListOfGoods()[0].Products);
                }
        }
    }
}




