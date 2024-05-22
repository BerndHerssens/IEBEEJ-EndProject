using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using IEBEEJ.Business.Models;
using IEBEEJ.Data.Entities;
using IEBEEJ.Data.Repositories;
using IEBEEJ.Business.Services;

namespace IEBEEJ.Business.Services
{
    public class BidService
    {
        private IBidRepository _bidRepository;

        public BidService()
        {

        }
        public async Task<BidEntity> CreateABidAsync(decimal value, int bidderID, int itemID)
        {
            BidEntity bidEntity = new BidEntity();
            bidEntity.BidValue = value;
            bidEntity.IsActive = true;
            bidEntity.BidderId = bidderID;
            bidEntity.ItemID = itemID;
            bidEntity.Created = DateTime.Now;
            await _bidRepository.CreateBidAsync(bidEntity);
            return bidEntity;
        }

    }
}
