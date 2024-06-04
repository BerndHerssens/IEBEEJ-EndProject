using IEBEEJ.Data.Entities;

namespace IEBEEJ.Data.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemEntity>> GetAllItemsAsync(int skip, int take);

        Task CreateItemAsync(ItemEntity itemEntity);

        Task RemoveItemAsync(ItemEntity entity);

        Task UpdateItemAsync(ItemEntity itemEntity);

        Task<ItemEntity> GetItemByIdAsync(int id);

        Task<List<ItemEntity>> GetItemsBySellerIDAsync(int userId);
        Task<IEnumerable<ItemEntity>> GetItemsByCategoryId(int id);
        Task<IEnumerable<ItemEntity>> GetAllItemsOnNameAsync(string searchname);
        Task ChangeItemActiveStatusAsync(ItemEntity itemEntity);
        Task ChangeItemSoldStatusAsync(ItemEntity itemEntity);
        Task<ItemEntity> GetOnlyItemAsync(int itemId);

        //Task<List<ItemEntity>> GetItemsBySellerNameAsync (int userId);
    }
}