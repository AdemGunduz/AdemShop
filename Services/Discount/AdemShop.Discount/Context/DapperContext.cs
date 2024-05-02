using AdemShop.Discount.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AdemShop.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration  _configuration;
        private readonly string  _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=AdemShopDiscountDb; User Id=sa; Password=P@ssw0rd; Trusted_Connection=False; Encrypt=True;TrustServerCertificate=True");
        }

        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString); //deparcontext üzerinden erişim
    }
}
