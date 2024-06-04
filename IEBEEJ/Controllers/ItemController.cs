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
                return NotFound();
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
                return NotFound();
            }
        }

        [HttpGet]
        [Route("SearchOnCategory")]
        public async Task<ActionResult<IEnumerable<Item>>> SearchOnCategory(int categoryInt)
        {
            IEnumerable<Item> filteredList = await _itemService.GetItemsByCategoryId(categoryInt);
            if (filteredList != null)
            {
                IEnumerable<ItemDTO> itemDTO = _mapper.Map<IEnumerable<ItemDTO>>(filteredList);
                return Ok(itemDTO);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("SearchOnName")]
        public async Task<ActionResult<IEnumerable<Item>>> SearchOnName(string name)
        {
            IEnumerable<Item> models = await _itemService.GetAllItemsAsync();
            Item searchedItem = models.Contains(models.FirstOrDefault(x => x.ItemName.Contains(name))) ? models.FirstOrDefault(x => x.ItemName == name) : null;
            if (searchedItem == null)
            {
                return NotFound();
            }
            return Ok(searchedItem);
        }

        [HttpGet]
        [Route("GetHighestBidOnItem")]
        public async Task<ActionResult> GetHighestBid(int id)
        {
            Item item = await _itemService.GetItemByIdAsync(id);
            await _itemService.GetHighestBidOnItem(item);
            return Ok(item.HighestBid);
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

        [HttpGet]
        [Route("GetItemsBySellerID")]
        public async Task<ActionResult> GetItemsBySellerID(int id)
        {
            IEnumerable<Item> items = await _itemService.GetItemsBySellerIDAsync(id);
            IEnumerable<ItemDTO> itemDTOs = _mapper.Map<IEnumerable<ItemDTO>>(items);

            if (itemDTOs != null)
            {
                return Ok(itemDTOs);
            }
            else
            {
                return NotFound();
            }
        }
    }
}