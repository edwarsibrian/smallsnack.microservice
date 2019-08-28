using Microsoft.EntityFrameworkCore;
using SmallSnack.Microservice.Domain.Entities;

namespace SmallSnack.Microservice.Domain.Repo
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<PurchaseHistory> PurchaseHistories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseHistory>()
                .HasOne(c => c.User)
                .WithMany(c => c.PurchaseHistories)
                .HasForeignKey(c => c.Id);


            modelBuilder.Entity<ProductPriceUpdtHistory>()
                .HasOne(c => c.Product)
                .WithMany(c => c.ProductPriceUpdtHistories)
                .HasForeignKey(c => c.Id);

        }
    }
}