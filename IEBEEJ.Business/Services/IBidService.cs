using IEBEEJ.Business.Models;

namespace IEBEEJ.Business.Services
{
    public interface IBidService
    {
        Task CreateABidAsync(decimal value, int bidderID, int itemID);
        Task DeleteWalkByIdAsycn(int id);
        Task<IEnumerable<Bid>> GetAllBidsAsync(int itemID);
        Task<Bid> GetBidByIdAsync(int id);
    }
}