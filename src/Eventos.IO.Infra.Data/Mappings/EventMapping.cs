using Eventos.IO.Domain.Events;
using Eventos.IO.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Infra.Data.Mappings
{
    public class EventMapping : EntityTypeConfiguration<Event>
    {
        public override void Map(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e => e.Name)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(e => e.Desc)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.DescriptionFull)
                .HasColumnType("varchar(500)");

            builder.Property(e => e.CompanyName)
                .HasColumnType("varchar(150)");

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.Tag);

            builder.Ignore(e => e.CascadeMode);

            builder.HasOne(e => e.Organizer)
                .WithMany(o => o.Events)
                .HasForeignKey(e => e.OrganizerId);

            builder.HasOne(e => e.Category)
                .WithMany(e => e.Events)
                .HasForeignKey(e => e.CategoryId)
                .IsRequired(false);
        }
    }
}
