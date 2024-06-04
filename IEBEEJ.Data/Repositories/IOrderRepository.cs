using IEBEEJ.Data.Entities;

namespace IEBEEJ.Data.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(OrderEntity orderEntity, ItemEntity itemEntity);

        Task<IEnumerable<OrderEntity>> GetAllOrdersAsync(int skip, int take);

        Task<OrderEntity> GetOrderByIdAsync(int id);

        Task<List<OrderEntity>> GetOrdersByBuyerIDAsync(int userId);

        Task RemoveOrderAsync(OrderEntity orderEntity);

        Task UpdateOrderAsync(OrderEntity orderEntity);
    }
}