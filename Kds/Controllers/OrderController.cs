using Kds.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Kds.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        [Route("orders")]
        public async Task<IActionResult> GetOrders()
        {
            return Ok();
        }

        [HttpGet]
        [Route("orders/{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("orders/{id}")]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            return Ok();
        }

        [HttpPut]
        [Route("orders/{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Order updatedOrder)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("orders/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("orders/{id}/items")]
        public async Task<IActionResult> GetOrderItems(int id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("orders/{id}/items")]
        public async Task<IActionResult> AddOrderItem(int id, OrderItem item)
        {
            return Ok();
        }

        [HttpPut]
        [Route(("orders/{id}/items/{itemId}"))]
        public async Task<IActionResult> UpdateOrderItem(int id, int itemId, OrderItem updatedItem)
        {
            return Ok();
        }

        [HttpDelete]
        [Route(("orders/{id}/items/{itemId}"))]
        public async Task<IActionResult> DeleteOrderItem(int id, int itemId)
        {
            return Ok();
        }
    }
}
