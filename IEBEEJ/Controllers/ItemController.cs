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

        [HttpGet]
        [Route("GetAllItems")]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
        {
            IEnumerable<Item> models = await _itemService.GetAllItemsAsync(); 
            IEnumerable<ItemDTO> itemDTOs = _mapper.Map<IEnumerable<ItemDTO>>(models);
            if (itemDTOs != null)
            {
                return Ok(itemDTOs);
            }
            else
            {
                return NotFound("Cannot find any Item lists");
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> Get(int id)
        {
            Item item = await _itemService.GetItemByIdAsync(id);
            ItemDTO itemDTO = _mapper.Map<ItemDTO>(item);

            if (itemDTO != null)
            {
                return Ok(itemDTO);
            }
            else
            {
                return NotFound("Cannot find item with id "+id);
            }
        }

        [HttpGet]
        [Route("SearchOnCategory")]
        public async Task<ActionResult<IEnumerable<Item>>> SearchOnCategory(int categoryInt)
        {
            IEnumerable<Item> filteredList =await _itemService.GetItemsByCategoryId(categoryInt);
            if (filteredList != null)
            {
                IEnumerable<ItemDTO> itemDTO = _mapper.Map<IEnumerable<ItemDTO>>(filteredList);
                return Ok(itemDTO);
            }
            else
            {
                return NotFound("Cannot find the category with int "+categoryInt);
            }
        }

        [HttpGet]
        [Route("SearchOnName")]
        public async Task<ActionResult<IEnumerable<Item>>> SearchOnName(string name)
        {
            IEnumerable<Item> item = await _itemService.SearchOnName(name);

            if (item != null)
            {
                IEnumerable<ItemDTO> itemDTO = _mapper.Map<IEnumerable<ItemDTO>>(item);
                return Ok(itemDTO);
            }
            else
            {
                return NotFound("Cannot find item with name" +name);
            }
        }

        [HttpGet]
        [Route("GetHighestBidOnItem")]
        public async Task<ActionResult> GetHighestBid(Item item)
        {
            await _itemService.GetHighestBidOnItem(item);
            if ( item != null)
            {
                ItemDTO itemDTO = _mapper.Map< ItemDTO > (item);
                return Ok(itemDTO);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<ActionResult> Post(AddItemDTO itemDTO)
        {
            try
            {
                Item item = _mapper.Map<Item>(itemDTO);
                await _itemService.CreateAnItem(item);
                return Created();
            }
            catch (Exception cannotCreate)
            {
                return BadRequest(cannotCreate.Message);
            }
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _itemService.DeleteItemAsync(id);
            return Created();
        }

        [HttpPut]
        [Route("UpdateItem")]
        public async Task<ActionResult> UpdateItemAsync(UpdateItemDTO updateItem)
        {
            if (ModelState.IsValid)
            {
                Item item = _mapper.Map<Item>(updateItem);
                await _itemService.UpdateItemAsync(item);
                return Created();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("ActivityChangeItem")]
        public async Task<ActionResult> ChangeItemActivityAsync(Item item)
        {
            
            if (ModelState.IsValid)
            {
                await _itemService.ChangeItemActiveStatusAsync(item);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("SoldStatusChange")]
        public async Task<ActionResult> ChangeItemSoldAsync(Item item)
        {
            
            if (ModelState.IsValid)
            {
                await _itemService.ChangeItemSoldStatusAsync(item);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
