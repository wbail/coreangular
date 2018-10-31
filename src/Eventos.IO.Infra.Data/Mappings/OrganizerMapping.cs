using Eventos.IO.Domain.Organizers;
using Eventos.IO.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos.IO.Infra.Data.Mappings
{
    public class OrganizerMapping : EntityTypeConfiguration<Organizer>
    {
        public override void Map(EntityTypeBuilder<Organizer> builder)
        {
            builder.Property(e => e.Name)
                .HasColumnType("varchar(80)")
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(e => e.Cpf)
                .HasColumnType("varchar(11)")
                .HasMaxLength(11)
                .IsRequired();

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);
        }
    }
}
