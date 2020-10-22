using AutoMapper;
using EgenOrderingSystem.API.DBContext;
using EgenOrderingSystem.API.Models;
using EgenOrderingSystem.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgenOrderingSystem.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private IOrderRepository _orderRepository;
        private IMapper _mapper;

        public OrdersController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            var ordersFromRepo = await _orderRepository.GetOrdersAsync();

            return Ok(_mapper.Map<IEnumerable<OrderDto>>(ordersFromRepo));
        }
        [HttpGet("{id}", Name="GetOrder")]
        public async Task<IActionResult> GetOrderByID(int id)
        {
            var ordersFromRepo = await _orderRepository.GetOrderAsync(id);
            if(ordersFromRepo == null)
            {
                return NotFound();
            }
            return Ok(ordersFromRepo);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDtoToInsert orderDtoToInsert)
        {
            var orderEntity = _mapper.Map<Entities.Order>(orderDtoToInsert);
            _orderRepository.AddOrder(orderEntity);
            await _orderRepository.SaveAsync();
            var orderToReturn = _mapper.Map<Models.OrderDto>(orderEntity);
            return CreatedAtRoute("GetOrder", new {orderId= orderToReturn.Id }, orderToReturn);
        }

        [HttpPost("orderscollection")]
        public async Task<IActionResult> CreateOrderCollection(IEnumerable<OrderDtoToInsert> orderDtoCollectionToInsert)
        {
            foreach(var orderDtoToInsert in orderDtoCollectionToInsert)
            {
                var orderEntity = _mapper.Map<Entities.Order>(orderDtoToInsert);
                _orderRepository.AddOrder(orderEntity);
            }
            await _orderRepository.SaveAsync();
            return Ok();
        }

    }
}
