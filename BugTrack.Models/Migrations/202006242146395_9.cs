namespace BugTrack.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Tickets", new[] { "AssignedToUserId" });
            AlterColumn("dbo.Tickets", "AssignedToUserId", c => c.Guid());
            CreateIndex("dbo.Tickets", "AssignedToUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tickets", new[] { "AssignedToUserId" });
            AlterColumn("dbo.Tickets", "AssignedToUserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Tickets", "AssignedToUserId");
        }
    }
}
