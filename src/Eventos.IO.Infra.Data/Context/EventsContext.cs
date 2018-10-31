using Eventos.IO.Domain.Events;
using Eventos.IO.Domain.Organizers;
using Eventos.IO.Infra.Data.Extensions;
using Eventos.IO.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Eventos.IO.Infra.Data.Context
{
    public class EventsContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public DbSet<Organizer> Organizers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.AddConfiguration(new EventMapping());

            modelBuilder.AddConfiguration(new OrganizerMapping());

            modelBuilder.AddConfiguration(new CategoryMapping());

            modelBuilder.AddConfiguration(new AddressMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
