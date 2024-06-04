using IEBEEJ.Business.Models;

namespace IEBEEJ.Business.Services
{
    public interface IItemService
    {
        Task ChangeItemActiveStatus(Item item);
        Task ChangeItemSoldStatus(Item item);
        Task CreateAnItem(Item item);
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task GetHighestBidOnItem(Item item);
        Task<Item> GetItemByIdAsync(int id);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(int id);
        Task<IEnumerable<Item>> GetItemsByCategoryId(int id);
        Task<IEnumerable<Item>> GetItemsBySellerIDAsync(int id);
    }
}