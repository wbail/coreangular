using Eventos.IO.Domain.Events;
using Eventos.IO.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Eventos.IO.Infra.Data.Mappings
{
    public class AddressMapping : EntityTypeConfiguration<Address>
    {
        public override void Map(EntityTypeBuilder<Address> builder)
        {

            builder.Property(e => e.Street)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.Number)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.Neibourhood)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.PostalCode)
                .IsRequired()
                .HasMaxLength(8)
                .HasColumnType("varchar(8)");

            builder.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.State)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.HasOne(c => c.Event)
                .WithOne(c => c.Address)
                .HasForeignKey<Address>(c => c.EventId)
                .IsRequired(false);

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);
        }
    }
}
