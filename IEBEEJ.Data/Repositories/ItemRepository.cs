using IEBEEJ.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEBEEJ.Data.Repositories
{
    internal class ItemRepository : IItemRepository
    {
        private IEBEEJDBContext _dbcontext;
        
        public ItemRepository(IEBEEJDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task CreateItemAsync(ItemEntity itemEntity)
        {
            await _dbcontext.Items.AddAsync(itemEntity);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemEntity>> GetAllItemsAsync(int skip, int take)
        {
            return await _dbcontext.Items
                
                .Skip(skip)
                .Take(take)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public async Task<ItemEntity> GetItemByIdAsync(int id)
        {
            return await _dbcontext.Items
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ItemEntity>> GetItemsBySellerIDAsync(int userId)
        {
            return await _dbcontext.Items.Where(x => x.SellerID == userId).ToListAsync();
        }

        public Task RemoveItemByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateItemAsync(ItemEntity itemEntity)
        {
            throw new NotImplementedException();
        }

        /*public async Task<List<ItemEntity>> GetFilteredDataAsync(string category, int skip, int take)
        {
            return await _dbcontext.Items
                .Where(x => x.CategoryId = category )
                .Skip(skip)
                .Take(take)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }*/
    }
}
