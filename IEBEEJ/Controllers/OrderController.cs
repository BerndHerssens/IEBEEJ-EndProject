using AutoMapper;
using IEBEEJ.Business.Models;
using IEBEEJ.Business.Services;
using IEBEEJ.DTOs.OrderDTOs;
using Microsoft.AspNetCore.Mvc;

namespace IEBEEJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IMapper _mapper;
        private IOrderService _orderService;

        public OrderController(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<ActionResult> Post(AddOrderDTO addOrderDTO)
        {
            Order order = _mapper.Map<Order>(addOrderDTO);
            await _orderService.CreateOrderAsync(order);
            return Created();
        }

        [HttpPut]
        [Route("UpdateOrderStatus")]
        public async Task<ActionResult> UpdateOrderStatus(UpdateOrderStatusDTO updatedOrderstatusDTO)
        {
            if (ModelState.IsValid)
            {
                Order order = _mapper.Map<Order>(updatedOrderstatusDTO);
                await _orderService.UpdateOrderAsync(order);
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("GetOrderById")]
        public async Task<ActionResult> GetOrderById(int id)
        {
            Order order = await _orderService.GetOrderByIdAsync(id);
            OrderDTO orderDTO = _mapper.Map<OrderDTO>(order);
            if (order != null)
            {
                return Ok(orderDTO);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<ActionResult> GetAllOrders(int skip, int take)
        {
            IEnumerable<Order> orders = await _orderService.GetAllOrdersAsync(skip, take);
            if (orders != null)
            {
                return Ok(orders);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("GetOrdersByUserId")]
        public async Task<ActionResult> GetOrdersByUserId(int userId)
        {
            List<Order> orders = await _orderService.GetOrdersByUserIdAsync(userId);
            if (orders != null)
            {
                return Ok(orders);
            }
            return NotFound();
        }
    }


}
