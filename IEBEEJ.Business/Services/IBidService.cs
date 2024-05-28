using IEBEEJ.Business.Models;

namespace IEBEEJ.Business.Services
{
    public interface IBidService
    {
        Task CreateABidAsync(Bid bid);
        Task DeleteBidByIDAsync(int id);
        Task<IEnumerable<Bid>> GetAllBidsByItemIDAsync(int itemID);
        Task<Bid> GetBidByIdAsync(int id);
        Task UpdateBidAsync(Bid bid);
    }
}