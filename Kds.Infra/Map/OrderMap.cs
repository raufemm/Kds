using Kds.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kds.Infra.Map
{
    internal class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.Property(o => o.Id)
                .HasColumnName("OrderId")
                .ValueGeneratedNever()
                .IsRequired();
                
            builder.Property(o => o.OrderTime)
                .IsRequired();

            builder.Property(i => i.CustomerName)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(o => o.Status)
                .IsRequired();

            builder.HasMany(o => o.Items)
                .WithOne()
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            //.HasMany(ct => (ICollection<SettlementClosure>)ct.SettlementClosures)
            //    .WithOne()
            //    .HasForeignKey(x => x.ContractId);

            builder.Navigation(p => p.Items).AutoInclude();
        }
    }
}
