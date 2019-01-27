using System.Data.Entity;
using PingPongManagement.Models;

namespace PingPongManagement.Data
{
    public class PingPongDbContext : DbContext
    {
        public PingPongDbContext() : base("PingPongConnectionString")
        {
        }

        public static PingPongDbContext Create() => new PingPongDbContext();

        public DbSet<Player> Players { get; set; }
        public DbSet<SkillLevel> SkillLevels { get; set; }
    }
}
