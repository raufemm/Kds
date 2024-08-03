using Kds.Domain.Entities;
using Kds.Domain.Interfaces.Repositories;
using Kds.Domain.Interfaces.Services;

namespace Kds.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _repository;
        private readonly IGenericRepository<OrderItem> _repositoryItem;

        public OrderService(IGenericRepository<Order> repository, IGenericRepository<OrderItem> repositoryItem)
        {
            _repository = repository;
            _repositoryItem = repositoryItem;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Order> GetOrder(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Guid> CreateOrder(Order order)
        {
            var id = await _repository.InsertAsync(order);

            return id;
        }

        public async Task UpdateOrder(Guid id, Order order)
        {
            var updatedOrder = await _repository.GetAsync(id);

            updatedOrder.Update(order.CustomerName!, order.Status);

            await _repository.UpdateAsync(updatedOrder);
        }

        public async Task DeleteOrder(Guid id)
        {
            var order = await _repository.GetAsync(id);

            await _repository.DeleteAsync(order);
        }

        public async Task<IEnumerable<OrderItem>> GetItems(Guid id)
        {
            return await _repositoryItem.GetListAsync(id);
        }

        public async Task AddItemToOrder(Guid id, OrderItem item)
        {
            var order = await _repository.GetAsync(id);

            if (order is not null)
            {
                order.AddItem(item);

                await _repository.UpdateAsync(order);
            }
            else
                throw new InvalidOperationException("Order not found.");

        }

        public async Task UpdateItemOnOrder(Guid id, Guid orderItemId, OrderItem item)
        {
            var orderToUpdate = await _repository.GetAsync(id);

            orderToUpdate.UpdateItem(orderItemId, item);

            await _repository.UpdateAsync(orderToUpdate);
        }

        public async Task DeleteOrderItem(Guid id, Guid orderItemId)
        {
            var order = await _repository.GetAsync(id);

            var itemToDelete = order.Items?.FirstOrDefault(x => x.Id == orderItemId);

            if (itemToDelete != null)
            {
                order.RemoveItem(itemToDelete);

                await _repository.UpdateAsync(order);
            }
            else
                throw new InvalidOperationException("Item not found.");
        }
    }
}
