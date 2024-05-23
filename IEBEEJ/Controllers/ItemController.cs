using AutoMapper;
using IEBEEJ.Business.Models;
using IEBEEJ.Business.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IEBEEJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IMapper _mapper;
        private ItemService _itemService;

        public ItemController(IMapper mapper, ItemService itemService)
        {
            _mapper = mapper;
            _itemService = itemService;
        }

        // GET: api/<ItemController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
        {
            IEnumerable<Item> models = await _itemService.GetAllItemsAsync(); //TODO: map to DTO

            return Ok(models);
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ItemController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
