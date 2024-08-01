using Kds.Domain.Enum;

namespace Kds.Domain.Entities
{
    public class Order : Entity
    {
        public string? CustomerName { get; private set; }
        public DateTime OrderTime { get; private set; }
        public ICollection<OrderItem>? Items { get; private set; }
        public OrderStatus Status { get; private set; }

        public void Create(string customerName)
        {
            CustomerName = customerName;
            OrderTime = DateTime.Now;
            Items = new List<OrderItem>();
            Status = OrderStatus.InProgress;
        }

        public void AddItem(OrderItem item)
        {
            if (Items is null)
                Items = new List<OrderItem>();

            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items?.Remove(item);
        }
    } 
}
