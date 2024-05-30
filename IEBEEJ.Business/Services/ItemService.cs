using IEBEEJ.Data.Repositories;
using IEBEEJ.Business.Models;
using IEBEEJ.Data.Entities;
using AutoMapper;

namespace IEBEEJ.Business.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private IMapper _mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            ItemEntity itemEntity = await _itemRepository.GetItemByIdAsync(id);

            if (itemEntity != null)
            {
                Item item = _mapper.Map<Item>(itemEntity);
                return item;
            }
            else
            {
                return null;
            }
        }


        public async Task GetHighestBidOnItem(Item item)
        {
            if (item.AllBids != null || item.AllBids.Count > 0)
            {
                item.HighestBid = item.AllBids.OrderByDescending(x => x.BidValue).ToList()[0];
            }
        }

        public async Task ChangeItemActiveStatus(Item item)
        {
            item.IsActive = !item.IsActive;
            ItemEntity itemEntity = _mapper.Map<ItemEntity>(item);

            await _itemRepository.UpdateItemAsync(itemEntity);
        }

        public async Task ChangeItemSoldStatus(Item item)
        {
            item.IsSold = !item.IsSold;
            ItemEntity itemEntity = _mapper.Map<ItemEntity>(item);

            await _itemRepository.UpdateItemAsync(itemEntity);
        }

        public async Task CreateAnItem(Item item)
        {
            ItemEntity itemEntity = _mapper.Map<ItemEntity>(item);
            itemEntity.Created = DateTime.Now;
            itemEntity.EndDate = DateTime.Now.AddDays(7);
            await _itemRepository.CreateItemAsync(itemEntity);
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            IEnumerable<ItemEntity> itemEntitys = await _itemRepository.GetAllItemsAsync(0, 20);
            return _mapper.Map<IEnumerable<Item>>(itemEntitys);
        }

        public async Task UpdateItemAsync(Item item)
        {
            ItemEntity itemEntity = await _itemRepository.GetItemByIdAsync(item.Id);
            ItemEntity updatedEntity = _mapper.Map<ItemEntity>(item);

            itemEntity.ItemDescription = updatedEntity.ItemDescription;
            itemEntity.CategoryId = updatedEntity.CategoryId;
            itemEntity.SendingAdress = updatedEntity.SendingAdress;
            itemEntity.StartingPrice = updatedEntity.StartingPrice;
            itemEntity.EstimatedValueMax = updatedEntity.EstimatedValueMax;
            itemEntity.EstimatedValueMin = updatedEntity.EstimatedValueMin;
            itemEntity.ItemName = updatedEntity.ItemName;
            itemEntity.LastModified = DateTime.Now;

            await _itemRepository.UpdateItemAsync(itemEntity);
        }

        public async Task DeleteItemAsync(int id)
        {
            ItemEntity entitytoDelete = new ItemEntity { Id = id };

            await _itemRepository.RemoveItemByIDAsync(entitytoDelete);
        }

        public async Task<IEnumerable<Item>> GetItemsByCategoryId(int id)
        {
            IEnumerable<ItemEntity> itemEntitiess = await _itemRepository.GetItemsByCategoryId(id);
            if (itemEntitiess != null)
            {
               IEnumerable<Item> items = _mapper.Map<IEnumerable<Item>>(itemEntitiess);
                return items;
            }
            else
            {
                return null;
            }
        }
    }
}