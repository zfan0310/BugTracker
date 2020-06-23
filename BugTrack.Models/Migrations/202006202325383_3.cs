namespace BugTrack.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "LockendDateUtc", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "LockendDateUtc", c => c.DateTime(nullable: false));
        }
    }
}
