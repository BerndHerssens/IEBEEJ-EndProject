using AutoMapper;
using IEBEEJ.Business.Models;
using IEBEEJ.Data.Entities;
using IEBEEJ.Data.Repositories;

namespace IEBEEJ.Business.Services
{
    public class BidService : IBidService
    {
        private IBidRepository _bidRepository;
        private IItemService _itemService;
        private IMapper _mapper;

        public BidService(IBidRepository bidRepository, IMapper mapper, IItemService itemService)
        {
            _bidRepository = bidRepository;
            _itemService = itemService;
            _mapper = mapper;
        }

        public async Task<Bid> GetBidByIdAsync(int id)
        {
            BidEntity bidEntity = await _bidRepository.GetBidByIDAsync(id);

            if (bidEntity != null)
            {
                Bid bid = _mapper.Map<Bid>(bidEntity);
                return bid;
            }
            else
            {
                return null;
            }
        }

        public async Task CreateABidAsync(Bid bid)
        {
            Bid highestBid = await _itemService.GetHighestBidOnItem(bid.ItemId);

            if (highestBid == null || bid.BidValue > highestBid.BidValue)
            {
                BidEntity bidEntity = _mapper.Map<BidEntity>(bid);
                await _bidRepository.CreateBidAsync(bidEntity);
            }
            else
            {
                throw new ArgumentOutOfRangeException($"A higher bid exists: {highestBid.BidValue}");
            }
        }

        public async Task DeleteBidByIDAsync(int id)
        {
            await _bidRepository.DeleteBiddingByIdAsync(id);
        }

        public async Task<IEnumerable<Bid>> GetAllBidsByItemIDAsync(int itemID)
        {
            IEnumerable<BidEntity> bidEntities = await _bidRepository.GetAllBidsOfItemIDAsync(itemID);
            List<Bid> bids = _mapper.Map<List<Bid>>(bidEntities);

            return bids;
        }

        public async Task UpdateBidAsync(Bid bid)
        {
            BidEntity bidEntity = _mapper.Map<BidEntity>(bid);
            await _bidRepository.UpdateBidAsync(bidEntity);

        }
    }
}
