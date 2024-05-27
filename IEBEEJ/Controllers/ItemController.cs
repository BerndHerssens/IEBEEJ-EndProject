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
            IEnumerable<ItemDTO> itemDTOs = _mapper.Map<IEnumerable<ItemDTO>>(models);
            return Ok(itemDTOs);
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> Get(int id)
        {
            Item item = await _itemService.GetItemByIdAsync(id);
            ItemDTO itemDTO = _mapper.Map<ItemDTO>(item);
            return Ok(itemDTO);
        }

        // POST api/<ItemController>
        [HttpPost]
        public async Task<ActionResult> Post(AddItemDTO itemDTO)
        {
            Item item = _mapper.Map<Item>(itemDTO);
            await _itemService.CreateAnItem(item);
            return Created();
        }

        [HttpGet]
        [Route("SearchOnCategory")]

        public async Task<ActionResult<IEnumerable<Item>>> SearchOnCategory(int categoryInt)
        {
            IEnumerable<Item> models = await _itemService.GetAllItemsAsync();
            List<Item> filteredList = _itemService.FilterItem(models.ToList(), categoryInt);
            return Ok(filteredList);
        }

        [HttpGet]
        [Route("SearchOnName")]

        public async Task<ActionResult<IEnumerable<Item>>> SearchOnName(string name)
        {
            IEnumerable<Item> models = await _itemService.GetAllItemsAsync();
            Item searchedItem = models.Contains(models.FirstOrDefault(x => x.ItemName.Contains(name))) ? models.FirstOrDefault(x => x.ItemName == name) : null;
            return Ok(searchedItem);
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
                await _itemService.UpdateItemAsync(item);
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
            await _itemService.UpdateItemAsync(item);
            return Ok();
        }

        [HttpPut]
        [Route("SoldStatusChange")]
        public async Task<ActionResult> ChangeItemSold(int id)
        {
            Item item = await _itemService.GetItemByIdAsync(id);
            await _itemService.ChangeItemSoldStatus(item);
            await _itemService.UpdateItemAsync(item);
            return Ok();
        }
    }
}
