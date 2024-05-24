using AutoMapper;
using IEBEEJ.Business.Models;
using IEBEEJ.Business.Services;
using IEBEEJ.DTOs.ItemDTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IEBEEJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IMapper _mapper;
        private IItemService _itemService;

        public ItemController(IMapper mapper, IItemService itemService)
        {
            _mapper = mapper;
            _itemService = itemService;
        }

        // GET: api/<ItemController>
        [HttpGet]
        [Route("GetAllItems")]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
        {
            IEnumerable<Item> models = await _itemService.GetAllItemsAsync(); //TODO: map to DTO

            return Ok(models);
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> Get(int id)
        {
            Item item = await _itemService.GetItemByIdAsync(id);
            return Ok(item);
        }

        // POST api/<ItemController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }




        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await _itemService.DeleteItemAsync(id);
        }

        [HttpPut]
        [Route("UpdateItem")]
        public async Task<ActionResult> UpdateItemAsync(int id, UpdateItemDTO updateItem)
        {
            if (ModelState.IsValid)
            {
                Item item = _mapper.Map<Item>(updateItem);
                await _itemService.UpdateItemAsync(id, item);
                return Created();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("ActivityChangeItem")]
        public async Task<ActionResult> ChangeItemActivityAsync(int id)
        {
            Item item = await _itemService.GetItemByIdAsync(id);
            await _itemService.ChangeItemActiveStatus(item);
            await _itemService.UpdateItemAsync(id, item);
            return Ok();
        }

        [HttpPut]
        [Route("SoldStatusChange")]
        public async Task<ActionResult> ChangeItemSold(int id)
        {
            Item item = await _itemService.GetItemByIdAsync(id);
            await _itemService.ChangeItemSoldStatus(item);
            await _itemService.UpdateItemAsync(id, item);
            return Ok();
        }
    }
}
