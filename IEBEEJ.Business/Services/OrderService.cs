using AutoMapper;
using IEBEEJ.Business.Models;
using IEBEEJ.Data.Entities;
using IEBEEJ.Data.Repositories;

namespace IEBEEJ.Business.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IMapper _mapper;
        private IItemRepository _itemRepository;
        private IUserRepository _userRepository;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IItemRepository itemRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _itemRepository = itemRepository;
            _userRepository = userRepository;
        }

        public async Task CreateOrderAsync(Order order)
        {
            
            OrderEntity orderEntity = _mapper.Map<OrderEntity>(order);
            if (orderEntity == null)
            {
                throw new AutoMapperMappingException("Properties for OrderEntity and Order are not being mapped correctly.");
            }
            ItemEntity tempItemEntity = await _itemRepository.GetItemByIdAsync(order.ItemId);
            await _orderRepository.CreateOrderAsync(orderEntity, tempItemEntity);
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

        public async Task<List<Order>> GetAllOrdersAsync(int skip, int take)
        {
            IEnumerable<OrderEntity> orderEntities = await _orderRepository.GetAllOrdersAsync(skip, take);
            List<Order> orders = _mapper.Map<List<Order>>(orderEntities);
            return orders;
        }

        public async Task UpdateOrderAsync(Order order)
        {
            OrderEntity orderEntity = await _orderRepository.GetOrderByIdAsync(order.Id);
            OrderEntity updatedEntity = _mapper.Map<OrderEntity>(order);
            orderEntity.ItemEntityId = updatedEntity.ItemEntityId;
            orderEntity.BuyerId = updatedEntity.BuyerId;
            orderEntity.SellerName = updatedEntity.SellerName;
            orderEntity.SendAdress = updatedEntity.SendAdress;
            orderEntity.StatusId = updatedEntity.StatusId;
            orderEntity.IsActive = updatedEntity.IsActive;
            orderEntity.TotalCost = updatedEntity.TotalCost;
            orderEntity.StatusId = updatedEntity.StatusId;
            orderEntity.PaymentMethod = updatedEntity.PaymentMethod;

            await _orderRepository.UpdateOrderAsync(orderEntity);
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(int userId)
        {
            List<OrderEntity> orderEntities = await _orderRepository.GetOrdersByBuyerIDAsync(userId);
            List<Order> orders = _mapper.Map<List<Order>>(orderEntities);
            return orders;
        }

        public async Task UpdateOrderStatusAsync(Order order)  //todo: aparte gemaakt om tijdelijk status updates automatisch te kunnen updaten
        {
            OrderEntity orderEntity = await _orderRepository.GetOrderByIdAsync(order.Id);
            orderEntity.StatusId = order.StatusId;
            await _orderRepository.UpdateOrderAsync(orderEntity);
        }

        public async Task DeleteItemAsync(int id)
        {
           OrderEntity orderEntity = new OrderEntity { Id = id };
            await _orderRepository.RemoveOrderAsync(orderEntity);
        }
    }
}
