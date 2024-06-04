using IEBEEJ.Business.Models;

namespace IEBEEJ.Business.Services
{
    public interface IItemService
    {
        Task ChangeItemActiveStatusAsync(Item item);
        Task ChangeItemSoldStatusAsync(Item item);
        Task CreateAnItem(Item item);
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task<Bid> GetHighestBidOnItem(int id);
        Task<Item> GetItemByIdAsync(int id);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(int id);
        Task<IEnumerable<Item>> GetItemsByCategoryId(int id);
        Task<IEnumerable<Item>> GetItemsBySellerIDAsync(int id);
        Task<IEnumerable<Item>> SearchOnName(string name);

    }
}