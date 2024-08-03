namespace Kds.Domain.Entities
{
    public class OrderItem : Entity
    {
        public required string Name { get; set; }
        public required int Quantity { get; set; }
        public string? Notes { get; set; }
        public Guid OrderId { get; set; }
        //public virtual Order Order { get; set; }
    }
}
