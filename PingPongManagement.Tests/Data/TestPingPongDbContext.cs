using PingPongManagement.Data;
using PingPongManagement.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace PingPongManagement.Tests.Data
{
    /// <summary>
    /// Test DB Context that stores all table data in memory. Used to inject into controllers
    /// to prevent using a real database.
    /// </summary>
    public class TestPingPongDbContext : IPingPongDbContext
    {
        public TestPingPongDbContext()
        {
            this.Players = new TestPlayerDbSet();
            this.SkillLevels = new TestSkillLevelDbSet();
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<SkillLevel> SkillLevels { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        /// <summary>
        /// Populates the data set with default SkillLevels to mimic what is seeded in the DB creation.
        /// </summary>
        public void AddDefaultSkillLevels()
        {
            var defaultSkillLevels = new List<SkillLevel>
            {
                new SkillLevel { Id = 1, Name = "Beginner" },
                new SkillLevel { Id = 2, Name = "Intermediate" },
                new SkillLevel { Id = 3, Name = "Advanced" },
                new SkillLevel { Id = 4, Name = "Expert" }
            };

            defaultSkillLevels.ForEach(i => SkillLevels.Add(i));
        }
        
        public void MarkAsModified(object record) { }
        public void Dispose() { }
    }
}
