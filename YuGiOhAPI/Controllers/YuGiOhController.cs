using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YuGiOhAPI;
using System.Text.Json;
using System.Linq;

namespace YuGiOhAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YuGiOhController : ControllerBase
    {
        private readonly DataContext dataContext;

        public YuGiOhController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet("~/getall")]
        public async Task<ActionResult<List<Yugioh>>> Get()
        { 
            return Ok(await dataContext.YugiohDb.ToListAsync());
        }
        [HttpPost("~/addcard")]
        public async Task<ActionResult> Post([FromBody] Yugioh card)
        {
            dataContext.YugiohDb.Add(card);
            await dataContext.SaveChangesAsync();
            return Ok(await dataContext.YugiohDb.ToListAsync());
        }
        [HttpGet("~/getbyname")]
        public async Task<ActionResult> GetCardByName(string name)
        {
            var card = dataContext.YugiohDb.FindAsync(name);
            if (card != null)
                return Ok(card);
            else return new NotFoundResult();
        }
        [HttpGet("~/getcontains")]
        public async Task<ActionResult> GetCardsCointais(string name)
        {
            var cards = new List<Yugioh>();
            foreach (var card in dataContext.YugiohDb.ToList())
            {
                if (card.name.Contains(name))
                {
                    cards.Add(card);
                }
            }
            if (cards.Count > 0)
                return Ok(cards);
            else return new NotFoundResult();

        }
        [HttpPut]
        public async Task<ActionResult> UpdateCard(Yugioh request)
        {
            foreach (var card in dataContext.YugiohDb.Where(x => x.id == request.id))
            {
                card.name = request.name;
                card.desc = request.desc;
                card.str1 = request.str1;
                card.str2 = request.str2;
                card.str3 = request.str3;
                card.str4 = request.str4;
                card.str5 = request.str5;
                card.str6 = request.str6;
                card.str7 = request.str7;
                card.str8 = request.str8;
                card.str9 = request.str9;
                card.str10 = request.str10;
                card.str11 = request.str11;
                card.str12 = request.str12;
            }
            dataContext.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("~/getstatistics")]
    public async Task<ActionResult> TypeStatistics(String str1)
        {
            var typeCount = dataContext.YugiohDb.Where(x => x.str1.Contains(str1)).Count();
            return Ok(typeCount * 100 / dataContext.YugiohDb.ToList().Count());
        }
        [HttpDelete("~/deletecard")]
        public async Task<ActionResult> Delete(Yugioh card)
        {
            if (dataContext.YugiohDb.Contains(card))
                dataContext.YugiohDb.ToList().Remove(card);
            else return BadRequest();
        }
    }
}
