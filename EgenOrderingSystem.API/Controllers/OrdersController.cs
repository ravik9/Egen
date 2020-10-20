using AutoMapper;
using EgenOrderingSystem.API.DBContext;
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
        public ActionResult<IEnumerable<OrderDto>> GetOrders()
        {
            var ordersFromRepo = _orderRepository.GetOrders();

            return Ok(_mapper.Map<IEnumerable<OrderDto>>(ordersFromRepo));
        }
        [HttpGet("{id}")]
        public IActionResult GetOrderByID(int id)
        {
            var ordersFromRepo = _orderRepository.GetOrder(id);
            if(ordersFromRepo == null)
            {
                return NotFound();
            }
            return Ok(ordersFromRepo);
        }
    }
}
