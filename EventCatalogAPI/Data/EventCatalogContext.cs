using EventCatalogAPI.domain;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogAPI.Data
{
    public class EventCatalogContext:DbContext
    {
        public EventCatalogContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<EventCatagory> eventCatagories { get; set; }
        public DbSet<EventCatalog> eventCatalogs { get; set; }
        public DbSet<PopularEvent> popularEvents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventCatagory>(e =>
            {
                e.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                e.Property(c => c.Category)
                .IsRequired()
                .HasMaxLength(30);

               /* e.Property(c => c.Location)
                .IsRequired()
                .HasMaxLength(100);*/
                
            });
            modelBuilder.Entity<PopularEvent>(e =>
            {
                e.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                e.Property(p => p.EventName)
                .IsRequired()
                .HasMaxLength(100);

                /*e.Property(p => p.Location)
                .IsRequired()
                .HasMaxLength(100);*/


            });
            modelBuilder.Entity<EventCatalog>(e =>
            {
                e.Property(c => c.Price)
                .IsRequired();

                e.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                e.Property(c => c.Description)
                .HasMaxLength(100);

                e.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

                e.Property(c => c.Day)
                .IsRequired()
                .HasMaxLength(20);

                e.Property(c => c.Time)
                .IsRequired();

               /* e.Property(c => c.Location)
                .IsRequired();*/

                e.HasOne(b => b.PopularEvent)
                .WithMany()
                .HasForeignKey(e => e.PopularEventId);

                e.HasOne(b => b.EventCatagory)
                .WithMany()
                .HasForeignKey(t => t.EventCatagoryId);
                
              

             });

        }
    }
}
