using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using Microsoft.EntityFrameworkCore;
using WebApplication7.Repositories;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoodsController : ControllerBase
    {
        private readonly IGoodsRepository _goodsRepository;

        public GoodsController(IGoodsRepository goodsRepository)
        {
            this._goodsRepository = goodsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<GoodsStructure>> GetGoods()
        {
            return await _goodsRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GoodsStructure>> GetGoods(int id)
        {
            return await _goodsRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<GoodsStructure>>PostGood([FromBody] GoodsStructure goodsStructure) { 
        var newGood = await _goodsRepository.Create(goodsStructure);
            return CreatedAtAction(nameof(GetGoods), new { product = newGood.products }, newGood);
        }
    }
}