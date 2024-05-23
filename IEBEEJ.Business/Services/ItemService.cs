using IEBEEJ.Data.Repositories;
using IEBEEJ.Business.Models;
using IEBEEJ.Data.Entities;
using AutoMapper;

namespace IEBEEJ.Business.Services
{
    public class ItemService
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
            Item item = new Item();
            ItemEntity itemEntity = await _itemRepository.GetItemByIdAsync(id);

            if (itemEntity != null)
            {
                item.Id = itemEntity.Id;
                item.ItemName = itemEntity.ItemName;
                item.ItemDescription = itemEntity.ItemDescription;
                item.StartingPrice = itemEntity.StartingPrice;
                item.Created = itemEntity.Created;
                item.IsActive = itemEntity.IsActive;
                item.CategoryID = itemEntity.CategoryId;
                item.SellerID = itemEntity.SellerID;
                item.EndDate = itemEntity.EndDate;
                item.IsSold = itemEntity.IsSold;
                item.Category = (CategoryType)itemEntity.CategoryId;
                item.AllBids = itemEntity.AllBids.Select(b => new Bid
                {
                    ID = b.Id,
                    BidValue = b.BidValue,
                    TimeCreated = b.Created,
                    ItemID = b.ItemID,
                    BidderID = b.BidderId,
                    IsActive = b.IsActive
                }).ToList();
                return item;
            }
            else
            {
                return null;
            }
        }
        public async Task<Item> GetItemByIdAsync2(int id)
        {
            Item item = new Item();
            ItemEntity itemEntity = await _itemRepository.GetItemByIdAsync(id);

            if (itemEntity != null)
            {
                item = _mapper.Map<Item>(itemEntity);
                return item;
            }
            else
            {
                return null;
            }
        }

        public void GetHighestBidOnItem(Item item)
        {
            if (item.AllBids != null || item.AllBids.Count > 0)
            {
                item.HighestBid = item.AllBids.OrderByDescending(x => x.BidValue).ToList()[0];
            }
        }

        // TODO : itementity gelijkzetten aan itemmodel
    }
}
