﻿using IEBEEJ.Data.Repositories;
using IEBEEJ.Business.Models;
using IEBEEJ.Data.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace IEBEEJ.Business.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IBidRepository _bidRepository;
        private IMapper _mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper, IBidRepository bidRepository)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
            _bidRepository = bidRepository;
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

        public async Task<Bid> GetHighestBidOnItem(int id)
        {
            BidEntity entity = await _bidRepository.GetHighestBidForItem(id);
            Bid model = _mapper.Map<Bid>(entity);
            
            return model;
        }

        public async Task ChangeItemActiveStatusAsync(Item item)
        {
            if (item != null)
            {
                ItemEntity itemEntity = await _itemRepository.GetItemByIdAsync(item.Id);
                await _itemRepository.ChangeItemActiveStatusAsync(itemEntity);
            }
        }

        public async Task ChangeItemSoldStatusAsync(Item item)
        {
            if (item != null)
            {
                ItemEntity itemEntity = await _itemRepository.GetItemByIdAsync(item.Id);
                await _itemRepository.ChangeItemSoldStatusAsync(itemEntity);
            }
            else
            {
                throw new ArgumentNullException(nameof(item));
            }
        }

        public async Task CreateAnItem(Item item)
        {
            if (item != null) // Tip: Extra checks: Positieve prijs. Adres ingevuld. Email geldig.
            {
                ItemEntity itemEntity = _mapper.Map<ItemEntity>(item);
                if (itemEntity == null)
                {
                    throw new AutoMapperMappingException("Properties for ItemEntity and Item are not being mapped correctly.");
                }
                await _itemRepository.CreateItemAsync(itemEntity);
            }
            else
            {
                throw new ArgumentNullException(nameof(item));
            }
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

            // Dit kan (lees moet) via AutoMapper
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

            await _itemRepository.RemoveItemAsync(entitytoDelete);
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


        public async Task<IEnumerable<Item>> GetItemsBySellerIDAsync(int id)
        {
            IEnumerable<ItemEntity> itemEntity = await _itemRepository.GetItemsBySellerIDAsync(id);
            if (itemEntity != null)
            {
                IEnumerable<Item> items = _mapper.Map<IEnumerable<Item>>(itemEntity);
                return items;
            }
            return null;

        }
        public async Task<IEnumerable<Item>> SearchOnName(string name)
        {
            IEnumerable<ItemEntity> itemEntity = await _itemRepository.GetAllItemsOnNameAsync(name);
            if (itemEntity != null)
            {
                IEnumerable<Item> items = _mapper.Map<IEnumerable<Item>>(itemEntity);
                return items;
            }
            return null;

        }
    }
}