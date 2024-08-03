using Kds.Domain.Enum;

namespace Kds.Domain.Models
{
    public class UpdatedOrderModel
    {
        public string? CustomerName { get; set; }
        public OrderStatus Status { get; set; }
    }
}
