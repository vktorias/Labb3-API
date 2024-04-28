using Labb3_API.Models;
using Microsoft.EntityFrameworkCore; // Om modellerna finns i detta namespace

namespace Labb3_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<People> Peoples { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<PeopleInterest> PeopleInterests { get; set; }

    }
}
