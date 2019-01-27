namespace PingPongManagement.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PingPongManagement.Data.PingPongDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PingPongManagement.Data.PingPongDbContext context)
        {
            context.SkillLevels.AddOrUpdate(x => x.Id,
                new Models.SkillLevel { Id = 1, Name = "Beginner" },
                new Models.SkillLevel { Id = 2, Name = "Intermediate" },
                new Models.SkillLevel { Id = 3, Name = "Advanced" },
                new Models.SkillLevel { Id = 4, Name = "Expert" }
            );
        }
    }
}
