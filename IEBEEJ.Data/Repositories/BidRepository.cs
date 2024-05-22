using IEBEEJ.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEBEEJ.Data.Repositories
{
    public class BidRepository : IBidRepository
    {
        private IEBEEJDBContext _dbContext;

        public BidRepository(IEBEEJDBContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task CreateBidAsync(BidEntity bidEntity)
        {
            await _dbContext.Bids.AddAsync(bidEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBiddingByIdAsync(int bidID)
        {
            BidEntity bidEntity = new BidEntity() { ID = bidID };
            _dbContext.Bids.Remove(bidEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BidEntity>> GetAllBidsOfItemIDAsync(int itemID)
        {
            return await _dbContext.Bids
                .Where(x => x.ItemID == itemID)
                .OrderByDescending(x => x.BidValue)
                .ToListAsync();
        }

        public async Task<BidEntity> GetBidByIDAsync(int bidID)
        {
            return await _dbContext.Bids
               .SingleOrDefaultAsync(x => x.ID == bidID);
        }
    }
}
