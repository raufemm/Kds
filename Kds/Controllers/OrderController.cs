using AutoMapper;
using Kds.Domain.Entities;
using Kds.Domain.Interfaces.Services;
using Kds.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kds.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("orders")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetOrders();

            if (!orders.Any())
                return NotFound();

            return Ok(orders);
        }

        [HttpGet]
        [Route("orders/{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            var order = await _orderService.GetOrder(id);

            if (order is null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        [Route("orders")]
        public async Task<IActionResult> CreateOrder(CreatedOrderModel order)
        {
            var orderToCreate = _mapper.Map<Order>(order);

            var id = await _orderService.CreateOrder(orderToCreate);

            return Ok(id);
        }

        [HttpPut]
        [Route("orders/{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, UpdatedOrderModel updatedOrder)
        {
            var orderToUpdate = _mapper.Map<Order>(updatedOrder);

            await _orderService.UpdateOrder(id, orderToUpdate);

            return Ok();
        }

        [HttpDelete]
        [Route("orders/{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            if (id != Guid.Empty)
            {
                await _orderService.DeleteOrder(id);
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("orders/{id}/items")]
        public async Task<IActionResult> GetOrderItems(Guid id)
        {
            var itemsfromOrder = await _orderService.GetItems(id);

            if (itemsfromOrder is null) return NotFound();

            return Ok(itemsfromOrder);
        }

        [HttpPost]
        [Route("orders/{id}/items")]
        public async Task<IActionResult> AddOrderItem(Guid id, CreatedAndUpdatedOrderItemModel item)
        {
            if (id != Guid.Empty)
            {
                var itemToAdd = _mapper.Map<OrderItem>(item);

                await _orderService.AddItemToOrder(id, itemToAdd);

                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route(("orders/{id}/items/{itemId}"))]
        public async Task<IActionResult> UpdateOrderItem(Guid id, Guid itemId, CreatedAndUpdatedOrderItemModel updatedItem)
        {
            if (id != Guid.Empty && itemId != Guid.Empty)
            {
                var itemToUpdate = _mapper.Map<OrderItem>(updatedItem);

                await _orderService.UpdateItemOnOrder(id, itemId, itemToUpdate);

                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route(("orders/{id}/items/{itemId}"))]
        public async Task<IActionResult> DeleteOrderItem(Guid id, Guid itemId)
        {
            if (id != Guid.Empty && itemId != Guid.Empty)
            {
                await _orderService.DeleteOrderItem(id, itemId);

                return Ok();
            }

            return BadRequest();
        }
    }
}
