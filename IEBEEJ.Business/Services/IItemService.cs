using IEBEEJ.Business.Models;

namespace IEBEEJ.Business.Services
{
    public interface IItemService
    {
        Task ChangeItemActiveStatus(Item item);
        Task ChangeItemSoldStatus(Item item);
        Task CreateAnItem(Item item);
        List<Item> FilterItem(List<Item> itemList, int categoryInt);
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task GetHighestBidOnItem(Item item);
        Task<Item> GetItemByIdAsync(int id);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(int id);
    }
}