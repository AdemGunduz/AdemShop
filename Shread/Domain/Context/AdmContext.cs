using AdemShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Context
{
    public class AdmContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=AdemShopDb; User Id=sa; Password=P@ssw0rd; Trusted_Connection=False; Encrypt=True;TrustServerCertificate=True");
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
        public DbSet<Coupon> Coupons { get; set; }

    }
}
