using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BloodDonationApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):
            base(options)
        {
            
        }

        public DbSet<Donor> Donors { get; set; }
    }
}
