using IEBEEJ.Data.Entities;

namespace IEBEEJ.Data.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemEntity>> GetAllItemsAsync(int skip, int take);

        Task CreateItemAsync(ItemEntity itemEntity);

        Task RemoveItemByIDAsync(ItemEntity entity);

        Task UpdateItemAsync(ItemEntity itemEntity);

        Task<ItemEntity> GetItemByIdAsync(int id);

        Task<List<ItemEntity>> GetItemsBySellerIDAsync(int userId);

        //Task<List<ItemEntity>> GetItemsBySellerNameAsync (int userId);
    }
}