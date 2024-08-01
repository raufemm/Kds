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

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .ValueGeneratedOnAdd();

            builder.Property(o => o.OrderTime)
                .IsRequired();

            builder.Property(i => i.CustomerName)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(o => o.Status)
                .IsRequired();

            builder.HasMany(o => o.Items)
                .WithOne()
                .HasForeignKey(i => i.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
