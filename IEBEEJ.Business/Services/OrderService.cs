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
private IBidRepository _bidRepository;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IItemRepository itemRepository, IUserRepository userRepository, IBidRepository bidRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _itemRepository = itemRepository;
            _userRepository = userRepository;
            _bidRepository = bidRepository;
        }

        public async Task CreateOrderAsync(Order order)
        {
            UserEntity buyerEntity = await _userRepository.GetOnlyUserAsync(order.BuyerID);
            ItemEntity itemEntity = await _itemRepository.GetOnlyItemAsync(order.ItemId);
            UserEntity sellerEntity = await _userRepository.GetOnlyUserAsync(itemEntity.SellerId);
            BidEntity highestBid = await _bidRepository.GetHighestBidForItem(itemEntity.Id);
           

            if (highestBid.BidderId != buyerEntity.Id)
            {
                throw new KeyNotFoundException("This bid was not placed by this buyer.");
            }

            // Tip: This can also be automapped
            order.BuyerAdress = buyerEntity.Adress;
            order.BuyerName = buyerEntity.Name;

            order.SourceAdress = sellerEntity.Adress;
            order.SellerName = sellerEntity.Name;

            order.IsActive = true;
            order.PaymentMethod = "Cash";

            order.TotalCost = highestBid.BidValue * 1.21m;
            
            OrderEntity orderEntity = _mapper.Map<OrderEntity>(order);
            if (orderEntity == null)
            {
                throw new AutoMapperMappingException("Properties for OrderEntity and Order are not being mapped correctly.");
            }
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
            orderEntity.ItemId = updatedEntity.ItemId;
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
