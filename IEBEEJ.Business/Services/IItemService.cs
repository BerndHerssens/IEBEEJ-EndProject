using IEBEEJ.Business.Models;

namespace IEBEEJ.Business.Services
{
    public interface IItemService
    {
        Task ChangeItemActiveStatus(Item item);
        Task ChangeItemSoldStatus(Item item);
        void GetHighestBidOnItem(Item item);
        Task<Item> GetItemByIdAsync(int id);
        Task CreateAnItem(Item item);
    }
}