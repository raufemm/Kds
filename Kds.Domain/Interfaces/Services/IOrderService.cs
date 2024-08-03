using Kds.Domain.Entities;

namespace Kds.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task AddItemToOrder(Guid id, OrderItem item);
        Task<Guid> CreateOrder(Order order);
        Task DeleteOrder(Guid id);
        Task DeleteOrderItem(Guid id, Guid orderItemId);
        Task<IEnumerable<OrderItem>> GetItems(Guid id);
        Task<Order> GetOrder(Guid id);
        Task<IEnumerable<Order>> GetOrders();
        Task UpdateItemOnOrder(Guid id, Guid orderItemId, OrderItem item);
        Task UpdateOrder(Guid id, Order order);
    }
}
