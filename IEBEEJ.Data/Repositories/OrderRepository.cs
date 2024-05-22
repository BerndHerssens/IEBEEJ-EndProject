using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEBEEJ.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace IEBEEJ.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private IEBEEJDBContext _dbContext;

        public OrderRepository(IEBEEJDBContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task CreateOrderAsync(OrderEntity orderEntity)
        {
            await _dbContext.Orders.AddAsync(orderEntity);
            await _dbContext.SaveChangesAsync();
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
            return await _dbContext.Orders.Where(x => x.WonBidding.BidderId == userId).ToListAsync();
        }

        public async Task RemoveOrderByIdAsync(int id)
        {
            OrderEntity orderEntity = new OrderEntity { Id = id };
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
