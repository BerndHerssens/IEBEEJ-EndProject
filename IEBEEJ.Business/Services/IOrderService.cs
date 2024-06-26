﻿
using IEBEEJ.Business.Models;

namespace IEBEEJ.Business.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Order order);
        Task DeleteItemAsync(int id);
        Task<List<Order>> GetAllOrdersAsync(int skip, int take);
        Task<Order> GetOrderByIdAsync(int id);
        Task<List<Order>> GetOrdersByUserIdAsync(int userId);
        Task UpdateOrderAsync(Order order);


    }
}