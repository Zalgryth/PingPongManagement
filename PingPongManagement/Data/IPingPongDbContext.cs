using PingPongManagement.Models;
using System;
using System.Data.Entity;

namespace PingPongManagement.Data
{
    /// <summary>
    /// Interface for dealing with DataSets for the models, used to mock Entity Framework.
    /// </summary>
    public interface IPingPongDbContext : IDisposable
    {
        DbSet<Player> Players { get; set; }
        DbSet<SkillLevel> SkillLevels { get; set; }

        int SaveChanges();
        void MarkAsModified(object record);
    }
}
