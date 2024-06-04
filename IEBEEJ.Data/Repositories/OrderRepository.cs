using AutoMapper;
using IEBEEJ.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace IEBEEJ.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private IEBEEJDBContext _dbContext;
        private IMapper _mapper;

        public OrderRepository(IEBEEJDBContext dbcontext, IMapper mapper)
        {
            _dbContext = dbcontext;
            _mapper = mapper;
        }

        public async Task CreateOrderAsync(OrderEntity orderEntity, ItemEntity itemEntity)
        {
            try
            {
                List<BidEntity> bids = itemEntity.AllBids;
                orderEntity.TotalCost = bids.Max(x => x.BidValue) *1.21m; //move to bussiness
            }
            catch (Exception ex)
            {
                //logger.Log(ex.message("Something went wrong during creating at the reposity"))
                throw;
            }
            try
            {
                await _dbContext.Orders.AddAsync(orderEntity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //logger.Log(ex.message("Could not save and update DataBase.")
                throw new DbUpdateException("Could not save and update DataBase.", ex);
            }
        }

        public async Task<IEnumerable<OrderEntity>> GetAllOrdersAsync(int skip, int take)
        {
            return await _dbContext.Orders
                .Skip(skip)
                .Take(take)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public async Task<OrderEntity> GetOrderByIdAsync(int id)
        {
            return await _dbContext.Orders
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<OrderEntity>> GetOrdersByBuyerIDAsync(int userId)
        {
            return await _dbContext.Orders.Where(x => x.BuyerId == userId).ToListAsync();
        }

        public async Task RemoveOrderAsync(OrderEntity orderEntity)
        {
            _dbContext.Orders.Remove(orderEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(OrderEntity orderEntity)
        {
            _dbContext.Orders.Update(orderEntity);
            await _dbContext.SaveChangesAsync();
        }
    }
}