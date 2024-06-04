using IEBEEJ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEBEEJ.Data.Repositories
{
    public interface IBidRepository
    {
        Task<BidEntity> GetBidByIDAsync(int bidID);
        Task<IEnumerable<BidEntity>> GetAllBidsOfItemIDAsync(int itemID);
        Task CreateBidAsync(BidEntity bidEntity);
        Task DeleteBiddingByIdAsync(int bidID);
        Task UpdateBidAsync(BidEntity bidEntity);
        Task<BidEntity> GetHighestBidForItem(int id);
    }
}
