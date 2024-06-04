using AutoMapper;
using IEBEEJ.Business.Models;
using IEBEEJ.Business.Services;
using IEBEEJ.DTOs.OrderDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            if (ModelState.IsValid)
            {
                try
                {
                    Order order = _mapper.Map<Order>(addOrderDTO);
                    await _orderService.CreateOrderAsync(order);
                    return Created();

                }
                catch (KeyNotFoundException ex)
                {
                    //LogException(ex); Here we will save it in an internal logger, not yet implemented
                    return BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    //LogException(ex); Here we will save it in an internal logger, not yet implemented
                    return StatusCode(500, ex);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("UpdateOrderStatus")]
        public async Task<ActionResult> UpdateOrderStatus(UpdateOrderStatusDTO updatedOrderstatusDTO)
        {
            if (ModelState.IsValid)
            {
                Order order = _mapper.Map<Order>(updatedOrderstatusDTO);
                await _orderService.UpdateOrderAsync(order);
                return Created();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("GetOrderById")]
        public async Task<ActionResult<OrderDTO>> GetOrderById(int id)
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
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders(int skip, int take)
        {
            IEnumerable<Order> orders = await _orderService.GetAllOrdersAsync(skip, take);
            IEnumerable<OrderDTO> orderDTO = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            if (orderDTO != null)
            {
                return Ok(orderDTO);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("GetOrdersByUserId")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByUserId(int userId)
        {   
            IEnumerable<Order> orders = await _orderService.GetOrdersByUserIdAsync(userId);
            if (orders != null)
            {
                IEnumerable<OrderDTO> orderDTO = _mapper.Map<IEnumerable<OrderDTO>>(orders);
                return Ok(orderDTO);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("DeleteOrderById")]
        public async Task<ActionResult> Delete(int id)
        {
            await _orderService.DeleteItemAsync(id);
            return Created();
        }
    }


}
