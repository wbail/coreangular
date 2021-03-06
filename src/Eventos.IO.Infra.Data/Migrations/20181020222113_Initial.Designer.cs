﻿// <auto-generated />
using System;
using Eventos.IO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Eventos.IO.Infra.Data.Migrations
{
    [DbContext(typeof(EventsContext))]
    [Migration("20181020222113_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Eventos.IO.Domain.Events.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<Guid?>("EventId");

                    b.Property<string>("Neibourhood");

                    b.Property<string>("Number");

                    b.Property<string>("PostalCode");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .IsUnique()
                        .HasFilter("[EventId] IS NOT NULL");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Eventos.IO.Domain.Events.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Eventos.IO.Domain.Events.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AddressId");

                    b.Property<Guid?>("CategoryId");

                    b.Property<string>("CompanyName")
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Desc")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("DescriptionFull")
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("FinalDate");

                    b.Property<bool>("Free");

                    b.Property<bool>("IsOnline");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<Guid>("OrganizerId");

                    b.Property<DateTime>("StartDate");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OrganizerId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Eventos.IO.Domain.Organizers.Organizer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cpf");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Organizers");
                });

            modelBuilder.Entity("Eventos.IO.Domain.Events.Address", b =>
                {
                    b.HasOne("Eventos.IO.Domain.Events.Event", "Event")
                        .WithOne("Address")
                        .HasForeignKey("Eventos.IO.Domain.Events.Address", "EventId");
                });

            modelBuilder.Entity("Eventos.IO.Domain.Events.Event", b =>
                {
                    b.HasOne("Eventos.IO.Domain.Events.Category", "Category")
                        .WithMany("Events")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Eventos.IO.Domain.Organizers.Organizer", "Organizer")
                        .WithMany("Events")
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
