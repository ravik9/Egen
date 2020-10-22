using AutoMapper;
using EgenOrderingSystem.API.Entities;
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
    [Route("api/orders/{orderId}/items")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly IMapper _mapper;
        public OrderItemsController(IOrderRepository orderRepository, IOrderItemsRepository orderItemsRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _orderItemsRepository = orderItemsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItemDto>>> getOrderItems(int orderId)
        {
            if(!_orderRepository.OrderExists(orderId))
            {
                return NotFound();

            }
            var orderItemsFromEntity = await _orderRepository.GetOrderItemsAsync(orderId);
            return Ok(_mapper.Map<IEnumerable<OrderItemDto>>(orderItemsFromEntity));

        }

        [HttpGet("{itemId}", Name ="GetOrderItem" )]
        public async Task<ActionResult<OrderItemDto>> getOrderItem(int orderId, int itemId)
        {
            if (!_orderRepository.OrderExists(orderId))
            {
                return NotFound();

            }
            var orderItemsFromEntity = await _orderRepository.GetOrderItemAsync(orderId, itemId);
            if(orderItemsFromEntity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OrderItemDto>(orderItemsFromEntity));

        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderItem(int orderId, OrderItemsToInsert orderItemToInsert)
        {
            if (!_orderRepository.OrderExists(orderId))
            {
                return NotFound();
            }
            var orderItemEntity = _mapper.Map<Entities.OrderItems>(orderItemToInsert);
            //orderItemEntity.OrderId = orderId;
            _orderItemsRepository.AddOrderItem(orderId, orderItemEntity);
            await _orderItemsRepository.SaveAsync();
            var orderItemToReturn = _mapper.Map<Models.OrderItemDto>(orderItemEntity);
            return Ok();
        }

        [HttpPatch("{itemId}")]
        public async Task<ActionResult> PartiallyUpdateItemForOrder(int orderId, int itemId, JsonPatchDocument<ItemForUpdateDto> patchDocument)
        {
            if (!_orderRepository.OrderExists(orderId))
            {
                return NotFound();
            }

            var ItemForOrderFromRepo = await _orderItemsRepository.GetItemAsync(orderId, itemId);

            if (ItemForOrderFromRepo == null)
            {
                var itemDto = new ItemForUpdateDto();
                patchDocument.ApplyTo(itemDto);

                if (!TryValidateModel(itemDto))
                {
                    return ValidationProblem(ModelState);
                }

                var itemToAdd = _mapper.Map<Entities.OrderItems>(itemDto);
                itemToAdd.Id = itemId;

                _orderItemsRepository.AddOrderItem(orderId, itemToAdd);
                await _orderItemsRepository.SaveAsync();

                var courseToReturn = _mapper.Map<OrderItemDto>(itemToAdd);
                return StatusCode(201);

            }

            var itemToPatch = _mapper.Map<ItemForUpdateDto>(ItemForOrderFromRepo);
            patchDocument.ApplyTo(itemToPatch);

            if (!TryValidateModel(itemToPatch))
            {
                return ValidationProblem(ModelState);
            }

            patchDocument.ApplyTo(itemToPatch);
            _mapper.Map(itemToPatch, ItemForOrderFromRepo);

            _orderItemsRepository.UpdateOrderItem(ItemForOrderFromRepo);

            await _orderItemsRepository.SaveAsync();

            return NoContent();
        }

        [HttpPost("ordersitemscollection")]
        public async Task<IActionResult> CreateOrderItemsCollection(int orderId, IEnumerable<OrderItemsToInsert> orderItemsCollectionToInsertUpdate)
        {
            if (!_orderRepository.OrderExists(orderId))
            {
                return NotFound();
            }
            List<OrderItems> ItemsListToInsertOrUpdate = new List<OrderItems>();
            foreach (var OrderItemToInsertUpdate in orderItemsCollectionToInsertUpdate)
            {
                _orderItemsRepository.CreateOrderItem(_mapper.Map<Entities.OrderItems>(OrderItemToInsertUpdate));
            }
            await _orderRepository.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete("{itemId}")]
        public async Task<ActionResult> DeleteCourseForAuthor(int orderId, int itemId)
        {
            if (!_orderRepository.OrderExists(orderId))
            {
                return NotFound();
            }


            var itemForOrderFromRepo = await _orderItemsRepository.GetItemAsync(orderId, itemId);

            if (itemForOrderFromRepo == null)
            {
                return NotFound();
            }

            _orderItemsRepository.DeleteItem(itemForOrderFromRepo);
            await _orderItemsRepository.SaveAsync();

            return NoContent();
        }
    }
}
