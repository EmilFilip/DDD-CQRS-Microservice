using Microsoft.EntityFrameworkCore;

namespace STC.Customer.Infrastructure.DBContexts
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Entities.Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entities.Customer>()
                .ToTable("Customers")
                .HasIndex(cmpt => cmpt.CustomerId);
        }
    }
}
