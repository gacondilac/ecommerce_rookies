using BackendAPI.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Data
{
    public class RookieShopdbcontext : DbContext

    {
        public RookieShopdbcontext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<BackendAPI.Models.Product> products { get; set; } = default!;

    }
}
