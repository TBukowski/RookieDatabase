using RookieDatabase.Models;
using Microsoft.EntityFrameworkCore;
using RookieDatabase.ViewModels;

namespace RookieDatabase.Data
{
    public class RookieContext : DbContext
    {
        public RookieContext(DbContextOptions<RookieContext> options) : base(options)
        {
            //if (options == null)
            //{
            //    throw new ArgumentNullException(nameof(options));
            //}
        }
        public DbSet<Player> Player { get; set; }
    }
}