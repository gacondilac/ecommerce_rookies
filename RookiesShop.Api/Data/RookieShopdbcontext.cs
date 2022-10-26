using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RookiesShop.Api.Model;

namespace RookiesShop.Api.Data
{
    public class RookieShopdbcontext : IdentityDbContext<User>

    {
        public RookieShopdbcontext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }
     }
}
