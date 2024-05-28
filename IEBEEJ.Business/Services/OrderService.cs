using AutoMapper;
using IEBEEJ.Business.Models;
using IEBEEJ.Data.Entities;
using IEBEEJ.Data.Repositories;

namespace IEBEEJ.Business.Services
{
    internal class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task CreateOrderAsync(Order order)
        {
            OrderEntity orderEntity = _mapper.Map<OrderEntity>(order);
            await _orderRepository.CreateOrderAsync(orderEntity);
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            OrderEntity orderEntity = await _orderRepository.GetOrderByIdAsync(id);

            if (orderEntity != null)
            {
                Order order = _mapper.Map<Order>(orderEntity);
                return order;
            }
            else
            {
                return null; //TODO: throw exception
            }
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(int skip, int take)
        {
            IEnumerable<OrderEntity> orderEntities = await _orderRepository.GetAllOrdersAsync(skip, take);
            IEnumerable<Order> orders = _mapper.Map<IEnumerable<Order>>(orderEntities);
            return orders;

        }



        public async Task UpdateOrderAsync(Order order)
        {
            OrderEntity orderEntity = _mapper.Map<OrderEntity>(order);
            await _orderRepository.UpdateOrderAsync(orderEntity);
        }



        public async Task<List<Order>> GetOrdersByUserIdAsync(int userId)
        {
            List<OrderEntity> orderEntities = await _orderRepository.GetOrdersByBuyerIDAsync(userId);
            List<Order> orders = _mapper.Map<List<Order>>(orderEntities);
            return orders;
        }

        public async Task UpdateOrderStatusAsync(Order order)
        {
            OrderEntity orderEntity = await _orderRepository.GetOrderByIdAsync(order.Id);
            orderEntity.StatusId = order.StatusId;
            await _orderRepository.UpdateOrderAsync(orderEntity);
        }

        public async Task RemoveOrderByIdAsync(int id)
        {
            await _orderRepository.RemoveOrderByIdAsync(id);
        }

    }
}
