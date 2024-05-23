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

        public BidService(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }

        public async Task<Bid> GetBidByIdAsync(int id)
        {
            Bid bid = new Bid();
            BidEntity bidEntity = await _bidRepository.GetBidByIDAsync(id);

            if (bidEntity != null)
            {
                bid.ID = bidEntity.Id;
                bid.BidValue = bidEntity.BidValue;
                bid.TimeCreated = bidEntity.Created;
                bid.ItemID = bidEntity.ItemID;
                bid.BidderID = bidEntity.BidderId;
                bid.IsActive = bidEntity.IsActive;
                return bid;
            }
            else
            {
                return null;
            } 
        }

        public async Task<IEnumerable<Bid>> GetAllBidsAsync(int itemID)  // TODO : Automapper
        {
            List<Bid> bids = new List<Bid>();
            IEnumerable<BidEntity> bidEntities = await _bidRepository.GetAllBidsOfItemIDAsync(itemID);

            foreach (BidEntity bidEntity in bidEntities)
            {
                Bid bid = new Bid();
                bid.ID = bidEntity.Id;
                bid.BidValue = bidEntity.BidValue;
                bid.TimeCreated = bidEntity.Created;
                bid.ItemID = bidEntity.ItemID;
                bid.BidderID = bidEntity.BidderId;
                bid.IsActive = bidEntity.IsActive;
                bids.Add(bid);
            }

            return bids;
        }

        public async Task CreateABidAsync(decimal value, int bidderID, int itemID)
        {
            BidEntity bidEntity = new BidEntity();
            bidEntity.BidValue = value;
            bidEntity.IsActive = true;
            bidEntity.BidderId = bidderID;
            bidEntity.ItemID = itemID;
            bidEntity.Created = DateTime.Now;
            await _bidRepository.CreateBidAsync(bidEntity);
        }

        public async Task DeleteWalkByIdAsycn(int id)
        {
            await _bidRepository.DeleteBiddingByIdAsync(id);
        }


    }
}
