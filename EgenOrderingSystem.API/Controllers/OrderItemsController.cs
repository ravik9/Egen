using AutoMapper;
using EgenOrderingSystem.API.Models;
using EgenOrderingSystem.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgenOrderingSystem.API.Controllers
{
    [ApiController]
    [Route("api/orders/{orderId}/items")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderItemsController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<OrderItemDto>> getOrderItems(int orderId)
        {
            if(!_orderRepository.OrderExists(orderId))
            {
                return NotFound();

            }
            var orderItemsFromEntity = _orderRepository.GetOrderItems(orderId);
            return Ok(_mapper.Map<IEnumerable<OrderItemDto>>(orderItemsFromEntity));

        }

        [HttpGet("{itemId}")]
        public ActionResult<OrderItemDto> getOrderItem(int orderId, int itemId)
        {
            if (!_orderRepository.OrderExists(orderId))
            {
                return NotFound();

            }
            var orderItemsFromEntity = _orderRepository.GetOrderItem(orderId, itemId);
            if(orderItemsFromEntity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OrderItemDto>(orderItemsFromEntity));

        }
    }
}
