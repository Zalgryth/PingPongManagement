using System.Data.Entity;
using PingPongManagement.Models;

namespace PingPongManagement.Data
{
    /// <summary>
    /// Entity Framework Database Context.
    /// </summary>
    public class PingPongDbContext : DbContext, IPingPongDbContext
    {
        public PingPongDbContext() : base("PingPongConnectionString")
        {
        }

        public static PingPongDbContext Create() => new PingPongDbContext();

        public void MarkAsModified(object record)
        {
            Entry(record).State = EntityState.Modified;
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<SkillLevel> SkillLevels { get; set; }
    }
}
