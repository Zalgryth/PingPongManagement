namespace PingPongManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Age = c.Int(),
                        EmailAddress = c.String(nullable: false),
                        SkillLevel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SkillLevels", t => t.SkillLevel_Id, cascadeDelete: true)
                .Index(t => t.SkillLevel_Id);
            
            CreateTable(
                "dbo.SkillLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "SkillLevel_Id", "dbo.SkillLevels");
            DropIndex("dbo.Players", new[] { "SkillLevel_Id" });
            DropTable("dbo.SkillLevels");
            DropTable("dbo.Players");
        }
    }
}
