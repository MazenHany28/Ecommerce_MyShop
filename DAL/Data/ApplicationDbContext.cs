using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppIdentityUser,IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders {  get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProducts> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<AppIdentityUser>(e =>
            {
                e.ToTable("Users", t =>
                {
                    t.HasCheckConstraint("GenderConstraint", "[Gender] in ('M','F')");
                });

            });

            builder.Entity<Customer>().ToTable("Customers");
            builder.Entity<Buyer>().ToTable("Buyers");
            builder.Entity<Admin>().ToTable("Admins");

            builder.Entity<Product>(e =>
            {
               e.HasOne(p=>p.AddedByUser)
                .WithMany(u=>u.products)
                .HasForeignKey(p=>p.AddedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasMany(p=>p.orders)
                .WithOne(op=>op.product)
                .HasForeignKey(op=>op.ProductId)
                .OnDelete(DeleteBehavior.SetNull);

                e.HasOne(p => p.Category)
                .WithMany(c => c.products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
                
                e.ToTable(t =>
                {
                    t.HasCheckConstraint("Price", "[Price]>=0");
                    t.HasCheckConstraint("Stock", "[Stock]>=0");
                });

                e.HasIndex(p=>p.Name).IsUnique();

            });

            builder.Entity<Order>(e =>
            {
                e.HasOne(o=>o.customer)
                .WithMany(c=>c.Orders)
                .HasForeignKey(o=>o.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);

                e.HasMany(o => o.products)
                .WithOne(op => op.order)
                .HasForeignKey(op => op.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<OrderProducts>(e =>
            {
                e.ToTable(t =>
                {
                    t.HasCheckConstraint("Quantity", "[Quantity]>=0");
                });
            });


            builder.Entity<Category>(e =>
            {
                e.HasIndex(c =>c.Name).IsUnique();
            });

        }
    }
}
