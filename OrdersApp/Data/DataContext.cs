using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OrdersApp.Models;

namespace OrdersApp.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderSku> OrderSkus { get; set; }
        public DbSet<Sku> Skus{ get; set; }
        public DbSet<SkuCategory> SkuCategories { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {            
            base.OnConfiguring (optionsBuilder);
            optionsBuilder.UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Sku>()
                .HasOne(p => p.SkuCategory)
                .WithMany(pc => pc.Skus)
                .HasForeignKey(fk => fk.SkuCategoryId);

            modelBuilder.Entity<Order>()
                .HasOne(p => p.Customer)
                .WithMany(pc => pc.Orders)
                .HasForeignKey(fk => fk.CustomerId);

            //modelBuilder.Entity<OrderSku>()
            //    .HasKey(pc => new { pc.Order, pc.Sku});

            modelBuilder.Entity<OrderSku>()
                .HasOne(p => p.Order)
                .WithMany(pc => pc.OrderSkus)
                .HasForeignKey(fk => fk.OrderId);

            //modelBuilder.Entity<OrderSku>().HasNoKey();
        }
    }
}
