using Microsoft.EntityFrameworkCore;
using RoundingPortal_API.Models;

namespace RoundingPortal_API.Data
{
    public class RoundingContext : DbContext
    {
        public RoundingContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Lab> Labs {  get; set; }
        public DbSet<Workstation> Workstations { get; set; }

        public DbSet<WorkstationRecord> WorkstationRecords { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Issue> Issues { get; set; }
    }
}
