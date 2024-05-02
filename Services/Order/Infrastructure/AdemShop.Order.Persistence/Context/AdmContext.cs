using AdemShop.Order.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace AdemShop.Order.Persistence.Context
{
    public class AdmContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=AdemShopDiscountDb; User Id=sa; Password=P@ssw0rd; Trusted_Connection=False; Encrypt=True;TrustServerCertificate=True");
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }

    }
}
