namespace BugTrack.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "Users_Id", "dbo.Users");
            DropIndex("dbo.Projects", new[] { "Users_Id" });
            DropColumn("dbo.Projects", "Users_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Users_Id", c => c.Guid());
            CreateIndex("dbo.Projects", "Users_Id");
            AddForeignKey("dbo.Projects", "Users_Id", "dbo.Users", "Id");
        }
    }
}
