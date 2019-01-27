namespace PingPongManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SkillLevelForeignKey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Players", name: "SkillLevel_Id", newName: "SkillLevelId");
            RenameIndex(table: "dbo.Players", name: "IX_SkillLevel_Id", newName: "IX_SkillLevelId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Players", name: "IX_SkillLevelId", newName: "IX_SkillLevel_Id");
            RenameColumn(table: "dbo.Players", name: "SkillLevelId", newName: "SkillLevel_Id");
        }
    }
}
