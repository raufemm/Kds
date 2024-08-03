using AutoMapper;
using Kds.Domain.Entities;
using Kds.Domain.Models;

namespace Kds.Api.AutoMapper
{
    public class ModelToEntityMapping : Profile
    {
        public ModelToEntityMapping()
        {
            CreateMap<CreatedOrderModel, Order>()
                .AfterMap((src, dest) => dest.Create(src.CustomerName!));

            CreateMap<UpdatedOrderModel, Order>()
                .AfterMap((src, dest) => dest.Update(src.CustomerName!, src.Status));

            CreateMap<CreatedAndUpdatedOrderItemModel, OrderItem>();
        }        
    }
}
