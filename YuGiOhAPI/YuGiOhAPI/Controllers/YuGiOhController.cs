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
        private static readonly string _rootDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string _filepath = Path.Combine(_rootDirectory, "cardlist.json"); 
        using (FileStream filestream = new FileStream(_yugiohDb))
        public List<Yugioh> yugiohDb = JsonSerializer.Deserialize<List<Yugioh>>();
        [HttpGet("~/getall")]
        public async Task<ActionResult<List<Yugioh>>> Get()
        {
            return Ok(yugiohDb);
        }
        [HttpPost("~/addcard")]
        public async Task<ActionResult> Post([FromBody] Yugioh card)
        {
            yugiohDb.Add(card);
            JsonSerializer.Serialize(yugiohDb);
            return Ok();
        }
        [HttpGet("~/getbyname")]
        public async Task<ActionResult> GetCardByName(string name)
        {
            var card = yugiohDb.Find(x => x.name == name);
            if (card != null)
                return Ok(card);
            else return new NotFoundResult();
        }
        [HttpGet("~/getcontains")]
        public async Task<ActionResult> GetCardsCointais(string name)
        {
            var cards = new List<Yugioh>();
            foreach (var card in yugiohDb)
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
        [HttpPost("~/changeprice")]
        public async Task<ActionResult> ChangePrice(string price, string name)
        {
            var card = yugiohDb.Find(x => x.name == name);
            if (card == null)
            {
                return BadRequest();
            }
            else
            {
                yugiohDb
                    .Where(x => x.name == name)
                    .Select(x => x.price.tcgPlayerPrice = price);
                return Ok();
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateCard(Yugioh request)
        {
            foreach (var card in yugiohDb.Where(x => x.id == request.id))
            {
                card.name = request.name;
                card.price = request.price;
                card.desc = request.desc;
                card.type = request.type;
                card.race = request.race;
                card.archetype = request.archetype;
                card.set = request.set;
                card.image = request.image;
                card.atribute = request.atribute;
            }
            JsonSerializer.Serialize(yugiohDb);
            return Ok();
        }
        [HttpGet("~/getstatistics")]
    public async Task<ActionResult> TypeStatistics(String type)
        {
            var typeCount = yugiohDb.Where(x => x.type == type).Count();
            return Ok(typeCount * 100 / yugiohDb.Count());
        }
    }
}
