using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using RookiesShop.Api.Models;

namespace RookiesShop.Api.Data
{
    public class RookieShopdbcontext : DbContext

    {
        public RookieShopdbcontext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> products { get; set; } = default!;

    }
}
