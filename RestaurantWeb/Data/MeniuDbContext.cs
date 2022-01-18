using Microsoft.EntityFrameworkCore;
using RestaurantWeb.Models;

namespace RestaurantWeb.Data
{
    public class MeniuDbContext : DbContext
    {
        public MeniuDbContext(DbContextOptions<MeniuDbContext> options) : base(options)
        {

        }
        public DbSet<Meniu> menius { get; set; }
    }
}
