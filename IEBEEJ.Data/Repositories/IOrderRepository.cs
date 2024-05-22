using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEBEEJ.Data.Entities;

namespace IEBEEJ.Data.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(OrderEntity orderEntity);
        Task<IEnumerable<OrderEntity>> GetAllOrdersAsync(int skip, int take);
        Task<OrderEntity> GetOrderByIdAsync(int id);
        Task<List<OrderEntity>> GetOrdersByBuyerIDAsync(int userId);
        Task RemoveOrderByIdAsync(int id);
        Task UpdateOrderAsync(OrderEntity orderEntity);
    }
}
