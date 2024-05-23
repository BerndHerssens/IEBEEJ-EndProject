using IEBEEJ.Business.Models;

namespace IEBEEJ.Business.Services
{
    public interface IBidService
    {
        Task CreateABidAsync(decimal value, int bidderID, Item item);
        Task DeleteBidByIDAsync(int id);
        Task<IEnumerable<Bid>> GetAllBidsByItemIDAsync(int itemID);
        Task<Bid> GetBidByIdAsync(int id);
    }
}