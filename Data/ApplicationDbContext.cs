using Climbing4Everyone.Model;
using Climbing4Everyone2._0.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Climbing4Everyone2._0.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Route> ClimbingRoute { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
