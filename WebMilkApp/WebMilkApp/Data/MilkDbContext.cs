using Microsoft.EntityFrameworkCore;
using WebMilkApp.Models;

namespace WebMilkApp.Data
{
    public class MilkDbContext : DbContext
    {
        public MilkDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Milk> MilkInfo { get; set; } 
    }
}
