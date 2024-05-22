using IEBEEJ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEBEEJ.Data.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemEntity>> GetAllItemsAsync(int skip, int take);
        Task CreateItemAsync(ItemEntity itemEntity);
        Task RemoveItemByIDAsync(int id);
        Task UpdateItemAsync(ItemEntity itemEntity);
        Task<ItemEntity> GetItemByIdAsync(int id);
        Task<List<ItemEntity>> GetItemsBySellerIDAsync (int userId);

        //Task<List<ItemEntity>> GetItemsBySellerNameAsync (int userId);
        
    }
}
