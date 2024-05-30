using IEBEEJ.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEBEEJ.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private IEBEEJDBContext _dbContext;
        
        public ItemRepository(IEBEEJDBContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task CreateItemAsync(ItemEntity itemEntity)
        {
            await _dbContext.Items.AddAsync(itemEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemEntity>> GetAllItemsAsync(int skip, int take)
        {
            return await _dbContext.Items
                .Include(x => x.AllBids)
                .Include(x => x.Seller)
                .Include(x => x.Category)
                .Skip(skip)
                .Take(take)
                //.OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public async Task<ItemEntity> GetItemByIdAsync(int id)
        {
            return await _dbContext.Items  //TODO: Include want meerdere tables aanspreken, MAAR: oppassen met foreign keys en circular references
                .Include(x => x.AllBids)
                .Include(x => x.Seller)
                .Include(x => x.Category)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ItemEntity>> GetItemsBySellerIDAsync(int userId)
        {
            return await _dbContext.Items.Where(x => x.SellerId == userId).ToListAsync();
        }

        public async Task RemoveItemByIDAsync(ItemEntity entity)
        {
            _dbContext.Items.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateItemAsync(ItemEntity itemEntity)
        {
            _dbContext.Items.Update(itemEntity);
            await _dbContext.SaveChangesAsync();
        }

        /*public async Task<List<ItemEntity>> GetFilteredDataAsync(string category, int skip, int take)
        {
            return await _dbContext.Items
                .Where(x => x.CategoryId = category )
                .Skip(skip)
                .Take(take)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }*/
    }
}
